using UnityEngine;

/*
 *  @author Chase Franklin
 *  Audio trigger to play door opening sfx.
 */

public class AudioDoorOpen : MonoBehaviour
{
    [SerializeField] private MusicHandler musicHandler;
    [SerializeField] private FrameUtility frameUtility;
    private bool played = false;
    private void Update()
    {
        if (frameUtility.observed && !played)
        {
            musicHandler.doorOpen.Play();
            played = true;
        }
    }
}
