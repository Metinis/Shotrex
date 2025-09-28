using UnityEngine;

public class CoinSpriteController : MonoBehaviour
{
    private int frame = 0;
    private float timer = 0f;
    private SpriteRenderer sr;
    public Sprite[] sprites;
    public float frameRate = 0.3f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0f;
            frame = (frame + 1) % sprites.Length;
            sr.sprite = sprites[frame];
        }
    }
    
}
