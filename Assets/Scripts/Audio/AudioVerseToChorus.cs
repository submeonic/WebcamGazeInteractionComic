using UnityEngine;

/*
 *  @author Chase Franklin
 *  Handles a music transition from verse to chorus clips. Listens for a loop break from the AudioStart manager.
 */

public class AudioVerseToChorus : MonoBehaviour
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
            musicHandler.chorusMusic.Play();
            musicHandler.verseMusic.Stop();
            audioQueued = true;
        }
    }
}
