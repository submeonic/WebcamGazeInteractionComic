using UnityEngine;

/*
 * @author Chase Franklin
 * Rotates planet to front upon gaze interaction and handles if the planet is being selected or not.
 */

public class PlanetController : MonoBehaviour
{
    public Camera _camera;
    public int id;
    public float targetY; // the target Y value to rotate towards, can be set in the editor
    public float rotationSpeed = 0.05f; // the speed at which to rotate
    public bool selecting = false;

    private Quaternion targetRotation;
    private Quaternion currentRotation;
    private bool isColliding; // whether or not a collision is occurring
    private CapsuleCollider _collider;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _spriteRenderer = GetComponent<SpriteRenderer>();  
    }
    void Update()
    {
        int layerMask = 1 << 7;
        Ray center = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(center, out hit, Mathf.Infinity, layerMask))
        {
            if (_collider == hit.collider)
            {
                isColliding = true;
            }
            else
            {
                isColliding = false;
            }
        }
        else
        {
            isColliding = false;
        }

        if (isColliding)
        {
            // move infront of obscuring sprite
            _spriteRenderer.sortingLayerName = "DisplayedFrames";

            // get the current rotation of the parent object
            currentRotation = transform.parent.rotation;

            // calculate the target rotation
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, targetY, currentRotation.eulerAngles.z);

            // smoothly rotate towards the target rotation over time
            transform.parent.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            _spriteRenderer.sortingLayerName = "HiddenFrames";
        }

        //sprite turn to face camera
        transform.rotation = new Quaternion(0, 0, 0, 1);

        //exit conditions
        if (transform.position.z < -260 && isColliding)
        {
            selecting = true;
        }
        else 
        {
            selecting = false;
        }
    }
}
