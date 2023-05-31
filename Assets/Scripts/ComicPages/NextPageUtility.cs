using UnityEngine;
using UnityEngine.UI;

/*
 * @author Chase Franklin
 * Handles executing a next page selection and selection icon
 */

public class NextPageUtility : MonoBehaviour
{
    public Image fill;
    public GameObject canvasIcon;
    public MusicHandler musicHandler;
    public float currentValue, maxValue;
    private float observedTime;

    public GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            observedTime = Time.time;
            canvasIcon.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            currentValue = Time.time - observedTime;
            fill.fillAmount = Normalize();

            if (currentValue > maxValue)
            {
                musicHandler.pageFlipSound.Play();
                Action();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            currentValue = 0;
            canvasIcon.SetActive(false);
        }
    }

    private float Normalize()
    {
        return currentValue / maxValue;
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
