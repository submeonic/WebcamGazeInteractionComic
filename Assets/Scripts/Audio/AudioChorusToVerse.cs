using UnityEngine;

/*
 *  @author Chase Franklin
 *  Handles a music transition from chorus to verse clips. Listens for a loop break from the AudioStart manager.
 */

public class AudioChorusToVerse : MonoBehaviour
{
    [SerializeField] private AudioStart audioStart;
    [SerializeField] private MusicHandler musicHandler;
    private bool loopBreak;
    private bool audioQueued = false;

    private void Update()
    {
        loopBreak = audioStart.loopBreak;

        if (loopBreak && !audioQueued)
        {
            musicHandler.verseMusic.Play();
            musicHandler.chorusMusic.Stop();
            audioQueued = true;
        }
    }
}
