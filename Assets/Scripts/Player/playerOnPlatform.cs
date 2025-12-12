using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private PingPongScript platform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D c)
    {
        platform = c.collider.GetComponent<PingPongScript>();
        if (platform != null)
        {
            rb.linearVelocity = new Vector2(
                platform.platformVelocity.x,
                rb.linearVelocity.y
            );
        }
    }
}
