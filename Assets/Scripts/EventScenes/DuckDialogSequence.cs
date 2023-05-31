using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  @author Chase Franklin
 *  Activates dialog sequence before the duck race begins.
 */

public class DuckDialogSequence : MonoBehaviour
{
    [SerializeField] private List<DuckController> duckControllers = new List<DuckController>();
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private float delayTime = 5;
    [SerializeField] private Text text;
    [SerializeField] private GameObject canvas;
    [SerializeField] private string nextDialog;

    private void OnEnable()
    {
        Invoke("FirstSequence", delayTime);
        Invoke("SecondSequence", delayTime + 2);
    }

    private void FirstSequence()
    {
        text.text = nextDialog;
    }
    private void SecondSequence() 
    {
        musicHandler.raceStart.Play();
        canvas.SetActive(false);
        for (int i = 0; i < duckControllers.Count; i++)
        {
            duckControllers[i].isStarted = true;
        }
    }
}

