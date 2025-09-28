using System;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyType
{
    Ghost,
    Melee
}
public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    public float distanceAgro = 5f;
    public EnemyType enemyType = EnemyType.Ghost;

    private Rigidbody2D rb;
    private bool playerInRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInRange = Vector3.Distance(player.transform.position, transform.position) <= distanceAgro;
    }

    void FixedUpdate()
    {
        if (playerInRange)
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;

            if (enemyType == EnemyType.Ghost)
            {
                // Ghost floats (no gravity)
                rb.MovePosition(rb.position + directionToPlayer * speed * Time.fixedDeltaTime);
            }
            else
            {
                // Melee walks horizontally and keeps gravity
                directionToPlayer.y = 0;
                rb.linearVelocity = new Vector2(directionToPlayer.x * speed, rb.linearVelocity.y);
            }
        }
        else
        {
            // idle or patrol
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}

