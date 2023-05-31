using UnityEngine;

/*
 * @author Chase Franklin
 * Scales pages to fit the window the game is being played within.
 */

public class PageScaleToFit : MonoBehaviour
{

    void Start()
    {
        transform.localScale = new Vector3(Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
    }
}
