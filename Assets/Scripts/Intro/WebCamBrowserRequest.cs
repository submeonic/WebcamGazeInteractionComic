using UnityEngine;

public class WebCamBrowserRequest : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private bool cameraLoaded = false;
    private bool skip = false;

    private void Update()
    {

        if (!skip)
        {
            if (cameraLoaded)
            {
                skip = false;

                button.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}


