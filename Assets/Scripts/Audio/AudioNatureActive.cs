using UnityEngine;

/*
 *  @author Chase Franklin
 *  Audio trigger to play nature sfx.
 */

public class AudioNatureActive : MonoBehaviour
{
    [SerializeField] private MusicHandler musicHandler;
    private void OnEnable()
    {
        musicHandler.nature.Play();
    }
    private void OnDisable()
    {
        musicHandler.nature.Stop();
    }
}
