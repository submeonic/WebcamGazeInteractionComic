using UnityEngine;

/*
 *  @author Chase Franklin
 *  Controls gaze interactions with individual duck.
 */

public class DuckController : MonoBehaviour
{
    public bool isStarted = false;
    public int id;
    public Color color;

    [SerializeField] private float velocityScale;
    private Vector2 addedVelocity;

    private Rigidbody2D rb;
    private bool start = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        addedVelocity = new Vector3(0, -velocityScale);
    }

    private void Update()
    {
        if (isStarted && !start)
        {
            start = true;
        }

        if (start)
        {
            rb.gravityScale = 0.5f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (isStarted)
        {
            
            if (collision.gameObject.tag == "Pointer")
            {
                rb.velocity += addedVelocity;
            }
        }
    }
}
