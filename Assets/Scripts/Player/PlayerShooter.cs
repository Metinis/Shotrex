using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum Gun
{
    Pistol,
    Rifle,
    Shotgun
}
public class PlayerShooter : MonoBehaviour
{
    public GameObject bullet;
    private Gun currentGun = Gun.Pistol;
    private float shotCooldown = 0.5f;
    private float duration = 0.0f;
    private bool shot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetGun(currentGun);
    }

    // Update is called once per frame
    void Update()
    {
        bool shotHeld = Keyboard.current.zKey.isPressed && currentGun == Gun.Rifle;
        shot = Keyboard.current.zKey.wasPressedThisFrame;
        if ((shot || shotHeld) && duration > shotCooldown)
        {
            duration = 0.0f;
            Vector2 direction = Vector2.right;
            PlayerSpriteController controller = GetComponent<PlayerSpriteController>();
            if (controller.walkingRight && !controller.facingUp && !controller.facingDown)
            {
                direction = Vector2.right;
            }
            else if (!controller.walkingRight && !controller.facingUp && !controller.facingDown)
            {
                direction = Vector2.left;
            }
            else if (controller.walkingRight && controller.facingUp && !controller.idle)
            {
                direction = new Vector2(1f, 0.6f).normalized;
            }
            else if (!controller.walkingRight && controller.facingUp && !controller.idle)
            {
                direction = new Vector2(-1f, 0.6f).normalized;
            }
            else if(controller.facingUp && controller.idle)
            {
                direction = Vector2.up;
            }
            else if (controller.walkingRight && controller.facingDown && !controller.idle)
            {
                direction = new Vector2(1f, -0.6f).normalized;
            }
            else if (!controller.walkingRight && controller.facingDown && !controller.idle)
            {
                direction = new Vector2(-1f, -0.6f).normalized;
            }
            else if (controller.facingDown && controller.idle)
            {
                direction = Vector2.down;
            }
            bullet.GetComponent<BulletMovement>().direction = direction;
            Instantiate(bullet, transform.position, Quaternion.identity);
            if (currentGun == Gun.Shotgun)
            {
                int pelletCount = 3;
                float angleSpread = 10f;

                for (int i = 0; i < pelletCount; i++)
                {
                    float offset = (i - (pelletCount - 1) / 2f) * angleSpread;
                    
                    Vector2 spreadDir = Quaternion.Euler(0, 0, offset) * direction;
                    
                    bullet.GetComponent<BulletMovement>().direction = spreadDir.normalized;
                    Instantiate(bullet, transform.position, Quaternion.identity);
                }
            }
            
        }
    }

    void FixedUpdate()
    {
        duration += Time.fixedDeltaTime;
    }

    public void SetGun(Gun gun)
    {
        switch (gun)
        {
            case Gun.Pistol:
                shotCooldown = 0.5f;
                break;
            case Gun.Rifle:
                shotCooldown = 0.2f;
                break;
            case Gun.Shotgun:
                shotCooldown = 0.3f;
                break;
        }
        GetComponent<PlayerSpriteController>().SetSprites(gun);
        currentGun = gun;
    }

    public void UpgradeGun()
    {
        if(currentGun < Gun.Shotgun)
            SetGun(++currentGun);
    }

    public void DowngradeGun()
    {
        if (currentGun == Gun.Pistol)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        SetGun(--currentGun);
    }
}
