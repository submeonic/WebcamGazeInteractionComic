using UnityEngine;
using UnityEngine.Audio;

/*
 *  @author Chase Franklin
 *  Modifies the 3D environment coloring based on previous player choices, starts and synchronizes finale audio tracks
 *  handles transition into 3D Environment and the transition to the planet reveal.
 */

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject aliens;
    [SerializeField] private GameObject mainLight;
    [SerializeField] private GameObject lightPage;
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private GameObject loading;
    [SerializeField] private Camera fPCamera;
    [SerializeField] private float cameraRigScale = 0.05f;
    [SerializeField] private float environmentDelay = 2.0f;
    [SerializeField] private Material exitSkyBox;
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private AudioStart audioStart;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private EnvironmentPrep environmentPrep;

    [SerializeField] private GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private Color32 skyColor;
    private int loopCount = 0;

    private void Start()
    {
        cameraRig.transform.localScale = new Vector3(cameraRigScale, cameraRigScale, cameraRigScale);
        cameraRig.transform.position = new Vector3(0f, 31f, 0f);
        fPCamera.farClipPlane = 300;

        skyColor = environmentPrep.skyColor;
        mainLight.SetActive(false);
        lightPage.SetActive(false);

        musicHandler.verseMusic.Stop();
        musicHandler.chorusMusic.Stop();

        audioMixer.SetFloat("finaleBassVolume", -80f);
        audioMixer.SetFloat("finaleChoVolume", -80f);
        audioMixer.SetFloat("finaleSirenVolume", -80f);
        audioMixer.SetFloat("finaleVoxVolume", -80f);
        audioMixer.SetFloat("finaleLeadVolume", -80f);

        musicHandler.finaleBass.Play();
        musicHandler.finaleSiren.Play();
        musicHandler.finaleChords.Play();
        musicHandler.finaleLead.Play();
        musicHandler.finaleVox.Play();
        audioStart.loopstart = Time.time;

        Invoke("RevealEnvironment", environmentDelay);
    }

    private void RevealEnvironment()
    {
        loading.SetActive(false);

        fPCamera.backgroundColor = skyColor;

        for (int i = 0; i < environment.transform.childCount; i++)
        {
            GameObject child = environment.transform.GetChild(i).gameObject;
            child.layer = 0;
        }

        for (int i = 0; i < aliens.transform.childCount; i++)
        {
            GameObject child = aliens.transform.GetChild(i).gameObject;
            child.layer = 7;
        }
    }

    private void Update()
    {
        if (loopCount == 4 && audioStart.loopBreak)
        {
            Action();
        }
        else if (loopCount < 4 && audioStart.loopBreak)
        {
            loopCount++;
        }

    }
    private void OnDisable()
    {
        mainLight.SetActive(true);
        RenderSettings.skybox = exitSkyBox;

        fPCamera.farClipPlane = 1800;
        fPCamera.backgroundColor = Color.black;

        cameraRig.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        cameraRig.transform.position = new Vector3(0.0f, 30.0f, 0.0f);
        
        musicHandler.finaleBass.Stop();
        musicHandler.finaleSiren.Stop();
        musicHandler.finaleChords.Stop();
        musicHandler.finaleLead.Stop();
        musicHandler.finaleVox.Stop();
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
