using UnityEngine;
using UnityEngine.Audio;

/*
 * @author ChaseFranklin
 * Alien controller used to billboard sprites and trigger music queue upon gaze interaction
*/

public class AlienController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string audioGroup;
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider _collider;
    private bool lookedAt;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        // Get the direction vector from this game object to the player
        Vector3 direction = _camera.transform.position - transform.position;

        // Rotate this game object to face the player
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        if (!lookedAt)
        {
            int layerMask = 1 << 7;
            Ray center = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;

            if (Physics.Raycast(center, out hit, 30f, layerMask))
            {
                if (_collider == hit.collider)
                {
                    lookedAt = true;
                    audioMixer.SetFloat(audioGroup, 0f);
                    _spriteRenderer.color = Color.white;
                }
            }
        }
    }
}
