using System.Collections.Generic;
using UnityEngine;

/*
 *  @author Chase Franklin
 *  Observes results of duck race, appends color of ducks in the following photo, and triggers photo print when race concludes.
 */

public class DuckHandler : MonoBehaviour
{
    public MusicHandler musicHandler;
    public List<Color> duckList;
    public Color winningColor;
    public Color secondaryColor;
    public int primary;
    public int secondary;

    public SpriteRenderer photoDuck;
    public SpriteRenderer secondPhotoDuck;

    public GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Duck")
        {
            if (duckList.Count == 1)
            {
                secondaryColor = collision.gameObject.GetComponent<DuckController>().color;
                duckList.Add(secondaryColor);
                secondPhotoDuck.color = secondaryColor;
                secondary = collision.gameObject.GetComponent<DuckController>().id;
                Destroy(collision.gameObject);
            }
            else if (duckList.Count == 0)
            {
                winningColor = collision.gameObject.GetComponent<DuckController>().color;
                duckList.Add(winningColor);
                photoDuck.color = winningColor;
                primary = collision.gameObject.GetComponent<DuckController>().id;
                Destroy(collision.gameObject);
            }
            else
            {
                Color duckColor = collision.gameObject.GetComponent<DuckController>().color;
                duckList.Add(duckColor);
                Destroy(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (duckList.Count == 4)
        {
            musicHandler.cameraClick.Play();
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
