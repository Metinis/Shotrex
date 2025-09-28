using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private System.Random random;
    public float generateRate = 2.0f;
    private float duration = 0.0f;

    void Start()
    {
        random = new System.Random();
    }

    void FixedUpdate()
    {
        duration += Time.fixedDeltaTime;
        if (duration >= generateRate && GetComponent<EnemyMovement>().GetPlayerInRange())
        {
            int enemyInt = random.Next(0, enemies.Length);
            Instantiate(enemies[enemyInt], transform.position, Quaternion.identity);
            duration = 0.0f;
        }
    }
}
