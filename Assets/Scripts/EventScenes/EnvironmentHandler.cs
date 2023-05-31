using UnityEngine;

/*
 *  @author Chase Franklin
 *  Modifies the 3D environment coloring based on previous player choices, starts and synchronizes finale audio tracks
 *  handles transition into 3D Environment and the transition to the planet reveal.
 */

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private AudioStart audioStart;
    [SerializeField] private GameObject mainLight;
    [SerializeField] private GameObject lightPage;
    [SerializeField] private Light colorLight1;
    [SerializeField] private Light colorLight2;
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private Camera fPCamera;
    [SerializeField] private DuckHandler duckHandler;
    [SerializeField] private float cameraRigScale = 0.01f;
    [SerializeField] private float skyBoxDelay = 1.8f;
    [SerializeField] private Material exitSkyBox;

    [SerializeField] private GameObject[] activate, deactivate, delayedActivate, delayedDeactivate;
    [SerializeField] private float delayTime = 1.0f;

    private Color32 skyColor;
    private Color32 lightColor1;
    private Color32 lightColor2;


    private void OnEnable()
    {
        musicHandler.verseMusic.Stop();
        musicHandler.chorusMusic.Stop();
        audioStart.loopstart = Time.time;

        musicHandler.finaleBass.Play();
        musicHandler.finaleSiren.Play();
        musicHandler.finaleChords.Play();
        musicHandler.finaleLead.Play();
        musicHandler.finaleVox.Play();

        Invoke("Action", 36.576f);

        mainLight.SetActive(false);
        lightPage.SetActive(false);
    
        if (duckHandler.primary == 1) //blue
        {
            if (duckHandler.secondary == 2) //blue - green
            {
                skyColor = new Color32(143, 255, 169, 255);
                lightColor1 = new Color32(224, 204, 62, 255);
                lightColor2 = new Color32(1, 0, 255, 255);

                Debug.Log("blue - green");
            }
            else if (duckHandler.secondary == 3) //blue - pink
            {
                skyColor = new Color32(254, 196, 225, 255);
                lightColor1 = new Color32(225, 95, 246, 255);
                lightColor2 = new Color32(0, 22, 135, 255);

                Debug.Log("blue - pink");
            }
            else if (duckHandler.secondary == 4) //blue - purple
            {
                skyColor = new Color32(204, 144, 248, 255);
                lightColor1 = new Color32(177, 76, 248, 255);
                lightColor2 = new Color32(2, 22, 154, 255);

                Debug.Log("blue - purple");
            }
        }
        else if (duckHandler.primary == 2) //green
        {
            if (duckHandler.secondary == 1) //green - blue
            {
                skyColor = new Color32(133, 219, 255, 255);
                lightColor1 = new Color32(62, 244, 255, 255);
                lightColor2 = new Color32(5, 38, 8, 255);

                Debug.Log("green - blue");
            }
            else if (duckHandler.secondary == 3) //green - pink
            {
                skyColor = new Color32(255, 191, 250, 0);
                lightColor1 = new Color32(255, 0, 220, 255);
                lightColor2 = new Color32(0, 72, 9, 255);

                Debug.Log("green - pink");
            }
            else if (duckHandler.secondary == 4) //green - purple
            {
                skyColor = new Color32(172, 157, 255, 0);
                lightColor1 = new Color32(169, 62, 244, 255);
                lightColor2 = new Color32(0, 58, 7, 255);

                Debug.Log("green - purple");
            }
        }
        else if (duckHandler.primary == 3) //pink
        {
            if (duckHandler.secondary == 1) //pink - blue
            {
                skyColor = new Color32(119, 236, 255, 0);
                lightColor1 = new Color32(62, 208, 244, 255);
                lightColor2 = new Color32(138, 0, 127, 255);

                Debug.Log("pink - blue");
            }
            else if (duckHandler.secondary == 2) //pink - green
            {
                skyColor = new Color32(169, 255, 171, 0);
                lightColor1 = new Color32(42, 231, 0, 255);
                lightColor2 = new Color32(77, 0, 70, 255);

                Debug.Log("pink - green");
            }
            else if (duckHandler.secondary == 4) //pink - purple
            {
                skyColor = new Color32(182, 119, 255, 0);
                lightColor1 = new Color32(183, 62, 224, 255);
                lightColor2 = new Color32(96, 0, 89, 255);

                Debug.Log("pink - purple");
            }
        }
        else if (duckHandler.primary == 4) //purple
        {
            if (duckHandler.secondary == 1) //purple - blue
            {
                skyColor = new Color32(139, 208, 155, 0);
                lightColor1 = new Color32(98, 0, 226, 255);
                lightColor2 = new Color32(26, 23, 161, 255);

                Debug.Log("purple - blue");
            }
            else if (duckHandler.secondary == 2) //purple - green
            {
                skyColor = new Color32(183, 255, 179, 0);
                lightColor1 = new Color32(108, 178, 122, 255);
                lightColor2 = new Color32(15, 0, 77, 255);


                Debug.Log("purple - green");
            }
            else if (duckHandler.secondary == 3) //purple - pink
            {
                skyColor = new Color32(252, 220, 255, 0);
                lightColor1 = new Color32(218, 62, 224, 255);
                lightColor2 = new Color32(32, 0, 108, 255);

                Debug.Log("purple - pink");
            }
        }

        Invoke("UpdateSkyBox", skyBoxDelay);
        colorLight1.color = lightColor1;
        colorLight2.color = lightColor2;
        cameraRig.transform.localScale = new Vector3(cameraRigScale, cameraRigScale, cameraRigScale);
        cameraRig.transform.position = new Vector3(0f, 31f, 0f);
    }
    private void OnDisable()
    {
        fPCamera.backgroundColor = Color.black;
        mainLight.SetActive(true);
        RenderSettings.skybox = exitSkyBox;
        cameraRig.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        cameraRig.transform.position = new Vector3(0.0f, 30.0f, 0.0f);
        musicHandler.finaleBass.Stop();
        musicHandler.finaleSiren.Stop();
        musicHandler.finaleChords.Stop();
        musicHandler.finaleLead.Stop();
        musicHandler.finaleVox.Stop();
    }

    private void UpdateSkyBox()
    {
        fPCamera.backgroundColor = skyColor;
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
