using UnityEngine;

/*
 *  @author Chase Franklin
 *  Keeps track of when music can transition at the end of a bar.
 */

public class AudioStart : MonoBehaviour
{
    public bool startAudio = false;
    public bool loopBreak = false;
    public float loopstart;

    private bool audioStarted = false;
    private float loopLength = 9.144f;
    private float sinceAudioStart;
    private int loopCount;
    private int oldLoopCount;

    private void Update()
    {
        if (startAudio && !audioStarted)
        {
            audioStarted = true;
            loopstart = Time.time;
        }

        if (audioStarted)
        {
            sinceAudioStart = Time.time - loopstart;
            loopCount = (int)(sinceAudioStart / loopLength);
        }

        if (oldLoopCount != loopCount)
        {
            loopBreak = true;
        }
        else
        {
            loopBreak= false;
        }

        oldLoopCount = loopCount;
    }
}
