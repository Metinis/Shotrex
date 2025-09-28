using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        bool isPlayerBullet = gameObject.CompareTag("Bullet");
        bool otherIsPlayer = other.CompareTag("Player");
        bool otherIsBullet = other.CompareTag("Bullet");
        bool otherIsEnemy = other.CompareTag("Enemy");
        bool isEnemyBullet = gameObject.CompareTag("Enemy");
        if (isPlayerBullet && !otherIsPlayer && !otherIsBullet && !other.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
        else if (isEnemyBullet && !otherIsEnemy && !other.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
            
    }
    
}
