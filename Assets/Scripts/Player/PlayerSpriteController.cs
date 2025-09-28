using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpriteController : MonoBehaviour
{
    public Sprite idleSpritePistol;
    public Sprite jumpSpritePistol;
    public Sprite idleSpriteRifle;
    public Sprite jumpSpriteRifle;
    public Sprite idleSpriteShotgun;
    public Sprite jumpSpriteShotgun;
    public Sprite[] walkSpritesPistol;
    public Sprite[] walkSpritesRifle;
    public Sprite[] walkSpritesShotgun;
    private int walkFrame = 0;
    private float timer = 0f;

    private Sprite[] walkSprites;
    private Sprite jumpSprite;
    private Sprite idleSprite;

    public float frameRate = 0.1f;
    public bool walkingRight = true;
    public bool facingUp = false;
    public bool facingDown = false;
    public bool idle = true;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private PlayerController controller;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;

        if (Math.Abs(input.x) > 0 && controller.IsGrounded() && !controller.IsCrouching())
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                walkFrame = (walkFrame + 1) % walkSprites.Length;
                sr.sprite = walkSprites[walkFrame];
            }
        }
        else if(!controller.IsGrounded() || controller.IsCrouching())
        {
            sr.sprite = jumpSprite;
        }
        if (input.x > 0)
        {
            idle = false;
            if (!walkingRight)
            {
                Rotate();
            }
            walkingRight = true;
        }
        else if(input.x == 0 && controller.IsGrounded() && !controller.IsCrouching())
        {
            sr.sprite = idleSprite;
            idle = true;
        }
        else if (input.x < 0)
        {
            idle = false;
            if (walkingRight)
            {
                Rotate();
            }
            walkingRight = false;
        }

        if (input.y > 0)
        {
            facingDown = false;
            facingUp = true;
        }
        else if (input.y == 0)
        {
            facingUp = false;
            facingDown = false;
        }
        else if(input.y < 0)
        {
            facingUp = false;
            facingDown = true;
        }
        
    }

    void Rotate()
    {
        Collider2D col = GetComponent<Collider2D>();
        Vector3 center = col.bounds.center;
        transform.RotateAround(center, Vector3.up, 180f);
    }

    public void SetSprites(Gun gun)
    {
        if (gun == Gun.Pistol)
        {
            walkSprites = walkSpritesPistol;
            jumpSprite = jumpSpritePistol;
            idleSprite = idleSpritePistol;
        }
        else if (gun == Gun.Rifle)
        {
            walkSprites = walkSpritesRifle;
            jumpSprite = jumpSpriteRifle;
            idleSprite = idleSpriteRifle;
        }
        else
        {
            walkSprites = walkSpritesShotgun;
            jumpSprite = jumpSpriteShotgun;
            idleSprite = idleSpriteShotgun;
        }
    }
}