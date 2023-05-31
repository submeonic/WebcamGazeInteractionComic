using UnityEngine;

/*
 * @author Chase Franklin
 * Sets timing for planet reveal dialog and sequence of events.
 */

public class PlanetRevealDialog : MonoBehaviour
{
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject planetReveal;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private float textTime1;
    [SerializeField] private float textTime2;
    [SerializeField] private float planetTime;


    private void OnEnable()
    {
        musicHandler.finaleLoop.Play();
        Invoke("DisplayPlanet", planetTime);
        Invoke("DisplaySecond", textTime1);
    }
    
    private void DisplaySecond()
    {
        text1.SetActive(false);
        text2.SetActive(true);
        Invoke("ClearText", textTime2);
        
    }
    private void ClearText()
    {
        text2.SetActive(false);
    }
    private void DisplayPlanet()
    {
        planetReveal.SetActive(true);
        Invoke("QuitButton", 10f);
    }

    private void QuitButton()
    {
        quitButton.SetActive(true);
    }
}
