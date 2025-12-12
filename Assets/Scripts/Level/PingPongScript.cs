using UnityEngine;

public class PingPongScript : MonoBehaviour
{
    public float distance = 3f;
    public float speed = 2f;

    private float startX;
    public Vector2 platformVelocity;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float oldX = transform.position.x;

        float newX = startX + Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        platformVelocity = new Vector2(newX - oldX, 0f) / Time.deltaTime;
    }
}
