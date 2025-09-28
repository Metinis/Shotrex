using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpriteController : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite[] walkSprites;
    private int walkFrame = 0;
    private float timer = 0f;
    public float frameRate = 0.1f;
    public bool walkingRight = true;
    public bool facingUp = false;
    public bool idle = true;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;

        if (Math.Abs(input.x) > 0)
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                walkFrame = (walkFrame + 1) % walkSprites.Length;
                sr.sprite = walkSprites[walkFrame];
            }
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
        else if(input.x == 0)
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
            facingUp = true;
        }
        else
        {
            facingUp = false;
        }
        
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, 180);
    }
}