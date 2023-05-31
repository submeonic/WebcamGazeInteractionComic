using UnityEngine;
using UnityEngine.Audio;

/*
 *  @author Chase Franklin
 *  Controls the radio tuner and handles dynamic audio changes and exit logic.
 */

public class ClockRadio : MonoBehaviour
{
    public Transform pointer;
    public AudioMixer audioMixer;
    public MusicHandler musicHandler;
    public AudioStart audioStart;

    public float maxX = 245;
    public float minX = -90;
    public float songMaxX = 140;
    public float songMinX = 80;

    public bool inMusicRange = false;
    public float selectionTime = 3;
    private float initialCountTime;
    private float totalCountTime;

    public GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private void OnEnable()
    {
        audioStart.startAudio = true;
        musicHandler.verseMusic.Play();
        musicHandler.staticSound.Play();
    }
    void Update()
    {
        float pointerPosition = pointer.position.x;

        if (pointerPosition > minX && pointerPosition < maxX)
        {
            transform.position = new Vector2(pointerPosition, transform.position.y);
        }

        if (pointerPosition > songMinX && pointerPosition < songMaxX && !inMusicRange)
        {
            initialCountTime = Time.time;
            inMusicRange = true;
            audioMixer.SetFloat("verseMusicVolume", 0.0f);
            audioMixer.SetFloat("staticVolume", -30.0f);
        }
        else if (pointerPosition > songMinX && pointerPosition < songMaxX && inMusicRange)
        {
            totalCountTime = Time.time - initialCountTime;
        }
        else
        {
            inMusicRange = false;
            audioMixer.SetFloat("verseMusicVolume", -20.0f);
            audioMixer.SetFloat("staticVolume", -10.0f);
            totalCountTime = 0.0f;
        }

        if (totalCountTime > selectionTime)
        {
            musicHandler.staticSound.Pause();
            Action();
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
