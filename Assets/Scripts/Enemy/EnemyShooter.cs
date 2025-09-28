using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float cooldown = 1.5f;
    public GameObject bullet;
    private float duration = 0.0f;
    private bool shot = false;

    public void ShootAtTarget(Vector2 playerPos)
    {
        if (!shot)
        {
            Vector2 direction = new Vector2();
            if (playerPos.x > transform.position.x)
            {
                direction = Vector2.right;
            }
            else if (playerPos.x < transform.position.x)
            {
                direction = Vector2.left;
            }
            direction.y = 0;
            bullet.GetComponent<BulletMovement>().direction = direction;
            Instantiate(bullet, transform.position, Quaternion.identity);

            shot = true;
        }
    }

    void FixedUpdate()
    {
        if (shot)
        {
            duration += Time.fixedDeltaTime;
            if (duration >= cooldown)
            {
                duration = 0.0f;
                shot = false;
            }
        }
    }
}