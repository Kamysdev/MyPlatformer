using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public float bounceForce = 12f; // сила прыжка

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 normal = collision.contacts[0].normal;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        }
    }
}
