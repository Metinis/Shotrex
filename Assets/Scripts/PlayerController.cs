using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float acceleration = 8f;
    public LayerMask groundLayer;        // assign your floor layer

    private Rigidbody2D rb;
    private Vector2 input;
    
    bool jump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = 0;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;

        jump = Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded();
        if (jump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = input.x * movementSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float movement = Mathf.Sign(speedDiff) * acceleration * Time.fixedDeltaTime;
        if (Mathf.Abs(movement) > Mathf.Abs(speedDiff)) movement = speedDiff;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x + movement, rb.linearVelocity.y);
    }

    bool IsGrounded()
    {
        // Get the collider attached to the player
        Collider2D col = GetComponent<Collider2D>();

        // Start the ray slightly above the bottom of the collider
        Vector2 rayOrigin = new Vector2(col.bounds.center.x, col.bounds.min.y + 0.01f);
    
        float rayLength = 0.1f; // small distance to check for ground
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);

        Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red);
        return hit.collider != null;
    }
}