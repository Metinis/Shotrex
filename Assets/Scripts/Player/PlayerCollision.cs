using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    public float invincibilityDuration = 1.0f;
    private float duration = 0.0f;
    private bool hit;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.CompareTag("Enemy"))
        {
            EnemyCollision();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCollision();
        }
    }

    private void EnemyCollision()
    {
        GetComponent<PlayerShooter>().DowngradeGun();
        gameObject.layer = LayerMask.NameToLayer("PlayerInvincible");
        hit = true;
        Flash();
    }

    void FixedUpdate()
    {
        if (hit)
        {
            if (duration <= invincibilityDuration)
            {
                duration += Time.fixedDeltaTime;
            }
            else
            {
                hit = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
                duration = 0.0f;
            }
        }
        
    }
    private void Flash()
    {
        StartCoroutine(DoFlash());
    }

    private System.Collections.IEnumerator DoFlash()
    {
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true; 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
