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
    bool crouch = false;
    
    private BoxCollider2D box;
    private CapsuleCollider2D capsule;

    private Vector2 boxOriginalSize;
    private Vector2 boxOriginalOffset;

    private Vector2 capsuleOriginalSize;
    private Vector2 capsuleOriginalOffset;

    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();

        if (box != null)
        {
            boxOriginalSize = box.size;
            boxOriginalOffset = box.offset;
        }
        if (capsule != null)
        {
            capsuleOriginalSize = capsule.size;
            capsuleOriginalOffset = capsule.offset;
        }

        originalScale = transform.localScale;
    }

    void Update()
    {
        input.x = 0;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.wKey.isPressed) input.y += 1;
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
        if (!crouch && IsCrouching())
        {
            crouch = true;
            HandleCrouch(crouch);
        }
        else if (crouch && !IsCrouching())
        {
            crouch = false;
            HandleCrouch(crouch);
        }
        
        
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
    void HandleCrouch(bool crouching)
    {
        // collider part
        if (box != null)
        {
            if (crouching)
            {
                box.size = new Vector2(boxOriginalSize.x, boxOriginalSize.y * 0.5f);
                box.offset = new Vector2(boxOriginalOffset.x, boxOriginalOffset.y * 0.5f);
            }
            else
            {
                box.size = boxOriginalSize;
                box.offset = boxOriginalOffset;
            }
        }

        if (capsule != null)
        {
            if (crouching)
            {
                capsule.size = new Vector2(capsuleOriginalSize.x, capsuleOriginalSize.y * 0.5f);
                capsule.offset = new Vector2(capsuleOriginalOffset.x, capsuleOriginalOffset.y * 0.5f);
            }
            else
            {
                capsule.size = capsuleOriginalSize;
                capsule.offset = capsuleOriginalOffset;
            }
        }

        // sprite part (scale)
        if (crouching)
        {
            // scale down vertically
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
        }
        else
        {
            // reset scale
            transform.localScale = originalScale;
        }
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

    public bool IsCrouching()
    {
        return Keyboard.current.sKey.isPressed;
    }

    public bool IsJumping()
    {
        return jump;
    }
    
    
}