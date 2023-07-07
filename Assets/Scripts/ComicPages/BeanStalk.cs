using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 *  @author Chase Franklin
 *  Controls beanstalk graphic and handles exit logic on comic page 3.
 */

public class BeanStalk : MonoBehaviour
{
    public Image fill;
    public Transform pointer;
    public GameObject character;
    public AudioMixer audioMixer;
    public MusicHandler musicHandler;
    public float delayTime = 3f;

    private float startY = -150f;
    private float endY = 150f;

    public GameObject[] activate, deactivate, delayed, delayedActivate, delayedDeactivate;
    public float pageDelayTime = 1.0f;

    public GameObject[] observedFrames;
    private FrameUtility frameScript;
    private bool observed1, observed2, observed3, observed4, observed5, observed6 = false;
    private bool nextOption = false;
    private bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        fill.fillAmount = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        float targetY = Mathf.Clamp(pointer.position.y, startY, endY);
        float normalizedY = Mathf.InverseLerp(startY, endY, targetY);
        fill.fillAmount = 1 - normalizedY;

        if (nextOption) 
        {
            fill.fillAmount = 1;
            observedFrames[5].GetComponent<FrameUtility>().activelyObserved = true;

            float startX = -3.54f;
            float endX = -7.7f;
            float lerpSpeed = 0.005f;
            float targetX = character.transform.position.x;
            float lerpedX = Mathf.Lerp(transform.position.x, Mathf.Lerp(startX, endX, targetX), lerpSpeed * Time.deltaTime);

            transform.position = new Vector3(lerpedX, transform.position.y, transform.position.z);

            if (pointer.position.y > -150 && !played)
            {
                character.transform.position = new Vector3(lerpedX, targetY, character.transform.position.z);
                if (character.transform.position.y > 140.0f)
                {
                    audioMixer.SetFloat("sfxVolume", 0f);
                    musicHandler.synthSwell2.Play();
                    Invoke("Action", delayTime);
                    Invoke("PageFlipAudio", delayTime);
                    played = true;
                }
            }
        }


        if (!nextOption && observedFrames.Length > 0)
        {
            //observed frames update
            for (int i = 0; i < observedFrames.Length; i++)
            {
                frameScript = observedFrames[i].GetComponent<FrameUtility>();
                if (frameScript.observed)
                {
                    if (frameScript.id == 1 && !observed1)
                    { observed1 = true; }
                    if (frameScript.id == 2 && !observed2)
                    { observed2 = true; }
                    if (frameScript.id == 3 && !observed3)
                    { observed3 = true; }
                    if (frameScript.id == 4 && !observed4)
                    { observed4 = true; }
                    if (frameScript.id == 5 && !observed5)
                    { observed5 = true; }
                    if (frameScript.id == 6 && !observed6)
                    { observed6 = true;
                    }
                }
            }
            //page specific conditions
            if (observed1 && observed2 && observed3 && observed4 && observed5 && observed6 && !nextOption)
            {
                nextOption = true;
            }
        }
    }
    
    private void PageFlipAudio()
    {
        musicHandler.pageFlipSound.Play();
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
            Invoke("PerformDelayedDeactivate", pageDelayTime);
        }

        if (delayedActivate.Length > 0)
        {
            Invoke("PerformDelayedActivate", pageDelayTime);
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
