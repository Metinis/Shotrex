using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerShooter>().UpgradeGun();
            Destroy(gameObject);
        }
    }
}
