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
    private bool walkingRight = true;

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
            if (!walkingRight)
            {
                Rotate();
            }
            walkingRight = true;
        }
        else if(input.x == 0)
        {
            sr.sprite = idleSprite;
        }
        else if (input.x < 0)
        {
            if (walkingRight)
            {
                Rotate();
            }
            walkingRight = false;
        }
        
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, 180);
    }
}