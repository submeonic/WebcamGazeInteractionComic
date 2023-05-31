using UnityEngine;

/*
 * @author Chase Franklin
 * moves the camera rig forward through  the 3D environment.
 */

public class EnvironmentMove : MonoBehaviour
{
    [SerializeField] private GameObject cameraRig;
    [SerializeField] private float zSpeed = 1.5f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            Vector3 pos = cameraRig.transform.position;
            pos.z += zSpeed * Time.deltaTime;
            cameraRig.transform.position = pos;
        }
    }
    private void OnEnable()
    {
        Invoke("Moving", 3.0f);
    }
    private void OnDisable()
    {
        isMoving = false;
        cameraRig.transform.position = new Vector3(0f, 30f, 0f);
    }

    private void Moving()
    {
        isMoving = true;
    }
}
