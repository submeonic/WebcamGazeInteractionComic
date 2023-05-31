using UnityEngine;

/*
 * @author Chase Franklin
 * Controls the 2D gaze pointer based on user gaze.
 */

public class PointerPosition : MonoBehaviour
{
    public Camera _camera;
    public Vector2 _position;

    void FixedUpdate()
    {
        int layerMask = 1 << 6;
        Ray center = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(center, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = _position;
            _position = hit.point;
        }
    }
}   
