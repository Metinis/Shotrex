using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bullet;
    private bool shot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shot = Keyboard.current.zKey.wasPressedThisFrame;
        if (shot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        
    }
}
