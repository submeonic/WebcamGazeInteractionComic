using UnityEngine;

/*
 *  @author Chase Franklin
 *  Listens to FrameUtility states and handles exit conditions for comic page 2
 */

public class ComicP2Conditions : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject finalFrame;
    public GameObject[] observedFrames;
    private FrameUtility frameScript;

    private bool observed9, observed10, observed11;
    private bool openDoor = false;

    void Update()
    {
        if (!openDoor && observedFrames.Length > 0)
        {
            //observed frames update
            for (int i = 0; i < observedFrames.Length; i++)
            {
                frameScript = observedFrames[i].GetComponent<FrameUtility>();
                if (frameScript.observed)
                {
                    if (frameScript.id == 9 && !observed9)
                    { observed9 = true; }
                    if (frameScript.id == 10 && !observed10)
                    { observed10 = true; }
                    if (frameScript.id == 11 && !observed11)
                    { observed11 = true; }
                }
            }
            //page specific conditions
            if (observed9 && observed10 && observed11)
            {
                openDoor = true;
            }
        }
        else
        {
            closedDoor.SetActive(false);
            finalFrame.SetActive(true);
        }
    }
}
