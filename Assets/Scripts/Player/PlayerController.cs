using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Physics")]
    public float moveForce = 20f;
    public float maxSpeed = 7f;
    public float friction = 3f;

    [Header("Jump")]
    public float jumpForce = 12f;

    [Header("Rotation")]
    public float torqueForce = 10f; 

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer;

    [SerializeField] private HealthScript healthScript;

    [SerializeField] public float killSpeedThreshold = 8f;
    [SerializeField] public float killRotationThreshold = 150f;
    private Rigidbody2D rb;
    private float moveInput;
    private float rotateInput;
    private bool jumpPressed;
    private bool isGrounded;
    public static PlayerController instance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = false;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (jumpPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpPressed = false;
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleFriction();
        HandleRotation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthScript.TakeDamage(20f);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            healthScript.TakeDamage(40f);
        }
    }

    private void HandleMovement()
    {

        if (Mathf.Abs(rb.linearVelocity.x) < maxSpeed)
        {
            rb.AddForce(Vector2.right * moveInput * moveForce);
        }
    }

    private void HandleFriction()
    {
        if (Mathf.Abs(moveInput) < 0.01f)
        {
            Vector2 vel = rb.linearVelocity;
            vel.x = Mathf.Lerp(vel.x, 0f, friction * Time.fixedDeltaTime);
            rb.linearVelocity = vel;
        }
    }

    private void HandleRotation()
    {
        if (rotateInput != 0)
        {
            rb.AddTorque(-rotateInput * torqueForce);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
        rotateInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
            jumpPressed = true;
    }

    public void OnRotate(InputValue value)
    {
        rotateInput = value.Get<float>();
    }

    public bool IsInKillState()
    {
        float speed = rb.linearVelocity.magnitude;
        float rotation = Mathf.Abs(rb.angularVelocity);

        return speed > killSpeedThreshold && rotation > killRotationThreshold;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
