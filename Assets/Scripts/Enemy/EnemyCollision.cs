using UnityEngine;


public class EnemyCollision : MonoBehaviour
{
    public int health = 3;
    public int damage;
    public int scoreValue = 1;
    private float timer = 0.0f;
    private float durationCollision = 1.0f;
    bool flipped = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 1;
            GetComponent<Flash>().FlashSprite();
            if (health <= 0)
            {
                GameObject scoreSystem = GameObject.Find("ScoreSystem");
                scoreSystem.GetComponent<ScoreSystem>().AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CheckFlip(other.gameObject);
    }

    void CheckFlip(GameObject other)
    {
        if (other.gameObject.CompareTag("Tile") && !flipped)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

            // flip only when moving into the tile
            if (enemyMovement.facingLeft)
            {
                enemyMovement.Flip();
                
            }
            else if (!enemyMovement.facingLeft)
            {
                enemyMovement.Flip();
            }
            flipped = true;
        }
    }
    void FixedUpdate()
    {
        if (flipped)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= durationCollision)
            {
                flipped = false;
                timer = 0.0f;
            }
        }
    }

}
