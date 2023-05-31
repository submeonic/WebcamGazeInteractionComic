using UnityEngine;
using UnityEngine.Audio;

/*
 * @author Chase Franklin
 * observes planet options and handles choice selection and exit transition. 
 */

public class PlanetHandler : MonoBehaviour
{
    public int selectedPlanetID;
    public MusicHandler musicHandler;
    public AudioMixer audioMixer;
    public PlanetController[] planets;
    
    [SerializeField] private float selectionTime = 2.75f;

    public GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private float[] observedTime;
    private float[] currentValue;
    private bool[] selection;

    private void Start()
    {
        observedTime = new float[3];
        currentValue = new float[3];
        selection = new bool[3] {false, false, false};
    }

    private void Update()
    {
        for (int i = 0; i < planets.Length; i++)
        {

            if (planets[i].selecting && !selection[i])
            {
                observedTime[i] = Time.time;
                audioMixer.SetFloat("sfxVolume", -80f);
                musicHandler.synthSwell1.Play();
            }
            else if (planets[i].selecting && selection[i])
            {
                currentValue[i] = Time.time - observedTime[i];
                audioMixer.SetFloat("sfxVolume", ((currentValue[i] / selectionTime) * 10) - 10);
            }
            else if (!planets[i].selecting && selection[i])
            {
                musicHandler.synthSwell1.Stop();
            }

            selection[i] = planets[i].selecting;

            if (currentValue[i] > selectionTime)
            {
                selectedPlanetID = planets[i].id;
                Action();
            }
        }
    }

    private void Action()
    {
        //Trigger Utility
        if (activate.Length > 0)
        {
            for (int i = 0; i < activate.Length; i++)
            {
                activate[i].SetActive(true);
            }
        }

        if (deactivate.Length > 0)
        {
            for (int i = 0; i < deactivate.Length; i++)
            {
                deactivate[i].SetActive(false);
            }
        }

        if (delayedDeactivate.Length > 0)
        {
            Invoke("PerformDelayedDeactivate", delayTime);
        }

        if (delayedActivate.Length > 0)
        {
            Invoke("PerformDelayedActivate", delayTime);
        }
    }

    private void PerformDelayedDeactivate()
    {
        for (int i = 0; i < delayedDeactivate.Length; i++)
        {
            delayedDeactivate[i].SetActive(false);
        }
    }

    private void PerformDelayedActivate()
    {
        for (int i = 0; i < delayedActivate.Length; i++)
        {
            delayedActivate[i].SetActive(true);
        }
    }
}

