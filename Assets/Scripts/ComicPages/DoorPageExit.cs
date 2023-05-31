using UnityEngine;
using UnityEngine.Audio;

/*
 *  @author Chase Franklin
 *  Scales door when observed and executes exit conditions for comic page 2.
 */

public class DoorPageExit : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private float scaleSize = 4f;
    [SerializeField] private float scaleTime = 7.0f;
    [SerializeField] private GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;
    private bool observed = false;
    private bool action = false;
    private float observedTime;
    private Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            if (!observed)
            {
                musicHandler.synthSwell3.Play();
                observedTime = Time.time;
            }
            observed = true;
        }
    }

    private void Update()
    {
        if (observed)
        {
            float t = (Time.time - observedTime) / scaleTime;
            transform.localScale = Vector3.Lerp(startScale, new Vector3 (scaleSize, scaleSize, scaleSize), t);

            if (Time.time - observedTime > scaleTime && !action)
            {
                action = true;
                musicHandler.pageFlipSound.Play();
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
