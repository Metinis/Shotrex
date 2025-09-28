using UnityEngine;

public class EnemySpriteController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rigidbody2D;
    public Sprite idleSprite;
    public Sprite[] walkSprites;
    public Sprite jumpSprite;
    private int walkFrame = 0;
    private float timer = 0f;
    public float frameRate = 0.3f;
    private bool walking = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Rotate()
    {
        transform.Rotate(Vector3.up, 180);
    }

    void Update()
    {
        if (rigidbody2D.linearVelocity.magnitude > 0.1f)
        {
            timer += Time.deltaTime;
            if (timer >= frameRate)
            {
                timer = 0f;
                walkFrame = (walkFrame + 1) % walkSprites.Length;
                sr.sprite = walkSprites[walkFrame];
            }

            walking = true;
        }
        else
        {
            sr.sprite = idleSprite;
        }
    }
}
