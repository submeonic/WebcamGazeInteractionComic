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

    [SerializeField] private float gravityScale = 0.05f;
    [SerializeField] private float initialGravity = 0.5f;

    private Rigidbody2D rb;
    private bool start = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (isStarted && !start)
        {
            start = true;
        }

        if (start)
        {
            rb.gravityScale = initialGravity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isStarted)
        {
            if (collision.gameObject.tag == "Pointer")
            {
                rb.gravityScale += gravityScale;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isStarted)
        {
            if (collision.gameObject.tag == "Pointer")
            {
                rb.gravityScale = initialGravity;
            }
        }
    }
}
