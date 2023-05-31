using UnityEngine;

/*
 *  @author Chase Franklin
 *  Listens to FrameUtility states and handles exit conditions for comic page 1
 */

public class ComicP1Conditions : MonoBehaviour
{
    public GameObject NextIcon;
    public GameObject[] observedFrames;
    private FrameUtility frameScript;

    private bool observed1, observed2, observed3, observed4, observed5, observed6, observed7;
    private bool nextOption = false;

    void Update()
    {
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
                    { observed6 = true; }
                    if (frameScript.id == 7 && !observed7)
                    { observed7 = true; }
                }
            }
            //page specific conditions
            if (observed1 && observed2 && observed3 && observed4 && observed5 && observed6 && observed7)
            {
                nextOption = true;
            }
        }
        else
        {
            NextIcon.SetActive(true);
        }
    }
}
