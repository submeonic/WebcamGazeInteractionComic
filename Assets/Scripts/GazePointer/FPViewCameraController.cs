using UnityEngine;

/*
 * @author Chase Franklin
 * controls the view of camera by smoothing pose data from the HeadPose OpenCV implementation
*/

public class FPViewCameraController : MonoBehaviour
{
    public GameObject head;
    public float smoothSpeed = 1f;
    public float rotationSpeed = 5.0f;

    private Vector3 oldPos;
    private Quaternion oldRot;
    private Vector3 newPos;
    private Quaternion newRot;
    private Vector3 newAvgPos;
    private Quaternion newAvgRot;

    void Start()
    {
        oldPos = head.transform.position;
        oldRot = head.transform.rotation * Quaternion.Euler(0, 180, 0);
    }

    void LateUpdate()
    {
        newPos = head.transform.position;
        newRot = head.transform.rotation * Quaternion.Euler(0, 180, 0);

        newAvgPos = new Vector3((oldPos.x + newPos.x) / 2, (oldPos.y + newPos.y) / 2, (oldPos.z + newPos.z) / 2);
        newAvgRot = new Quaternion((oldRot.x + newRot.x) / 2, (oldRot.y + newRot.y) / 2, (oldRot.z + newRot.z) / 2, (oldRot.w + newRot.w) / 2);

        if (newPos != transform.position || newRot != transform.rotation)
        {
            transform.position = Vector3.Lerp(transform.position, newAvgPos, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newAvgRot, rotationSpeed * Time.deltaTime);
        }

        oldPos = newPos;
        oldRot = newRot;
    }
}
