using UnityEngine;


public class EnemyCollision : MonoBehaviour
{
    public int health;
    public int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
