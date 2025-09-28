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
    bool grounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = 0;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = input.x * movementSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float movement = Mathf.Sign(speedDiff) * acceleration * Time.fixedDeltaTime;
        if (Mathf.Abs(movement) > Mathf.Abs(speedDiff)) movement = speedDiff;
        grounded = IsGrounded();
        
        float yVelocity = rb.linearVelocity.y;
        if (grounded && !jump)
        {
            yVelocity = 0;
        }

        if (grounded && jump)
        {
            yVelocity = jumpForce;
            jump = false;
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x + movement, yVelocity);
        
    }

    public bool IsGrounded()
    {
        Collider2D col = GetComponent<Collider2D>();
    
        // Center of the BoxCast is slightly above the bottom of the collider
        Vector2 origin = new Vector2(col.bounds.center.x, col.bounds.min.y + 0.05f);

        // Make the box narrow (only cover the feet)
        Vector2 size = new Vector2(col.bounds.size.x * 0.5f, 0.1f); 

        float extraHeight = 0.05f; // small distance to check below feet

        RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0f, Vector2.down, extraHeight, groundLayer);

        // Draw for debugging
        Debug.DrawRay(origin, Vector2.down * (size.y/2 + extraHeight), Color.red);

        return hit.collider != null;
    }

    public bool IsJumping()
    {
        return jump;
    }
    
    
}