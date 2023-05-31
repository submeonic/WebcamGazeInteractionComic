using System.Collections.Generic;
using UnityEngine;

/*
 *  @author Chase Franklin
 *  Toggles text on or off based on observed state of the frame utility it is attatched to.
 */

public class DisplayText : MonoBehaviour
{
    public FrameUtility frame;
    public List<GameObject> text;

    private bool active = false;

    private void Update()
    {
        if(frame.activelyObserved && !active)
        {
            active= true;
        }
        else if(!frame.activelyObserved && active)
        {
            active = false;
        }

        if (active)
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].SetActive(false);
            }
        }
    }
}
