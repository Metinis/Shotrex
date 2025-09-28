using System;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyType
{
    Ghost,
    Melee,
    Ranged,
    Boss
}
public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    public float distanceAgro = 5f;
    public EnemyType enemyType = EnemyType.Ghost;

    private Rigidbody2D rb;
    private bool playerInRange;
    private Vector2 target;
    public bool facingLeft = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerInRange = Vector3.Distance(player.transform.position, transform.position) <= distanceAgro;
    }

    void FixedUpdate()
    {
        if (playerInRange)
        {
            target = (player.transform.position - transform.position).normalized;

            if (enemyType == EnemyType.Ghost || enemyType == EnemyType.Boss)
            {
                // Ghost floats (no gravity)
                rb.MovePosition(rb.position + target * speed * Time.fixedDeltaTime);
            }
            else
            {
                // Melee walks horizontally and keeps gravity
                target.y = 0;
                rb.linearVelocity = new Vector2(target.x * speed, rb.linearVelocity.y);
            }
            if (enemyType == EnemyType.Ranged)
            {
                GetComponent<EnemyShooter>().ShootAtTarget(player.transform.position);
            }

            if (player.transform.position.x > transform.position.x && facingLeft)
            {
                Flip();
            }
            else if (player.transform.position.x < transform.position.x && !facingLeft)
            {
                Flip();
            }
        }
        else
        {
            if (enemyType != EnemyType.Ghost && enemyType != EnemyType.Boss)
            {
                if(facingLeft)
                    rb.linearVelocity = new Vector2(Vector2.left.x * speed, rb.linearVelocity.y);
                else
                {
                    rb.linearVelocity = new Vector2(Vector2.right.x * speed, rb.linearVelocity.y);
                }
            }
            
        }
    }

    public void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(Vector2.up, 180f);
    }
    public Vector2 GetTarget()
    {
        return target;
    }

    public bool GetPlayerInRange()
    {
        return playerInRange;
    }
}

