using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 3f;
    public Vector2 direction = Vector2.right;
    private float duration = 0.0f;
    void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * speed * direction);
    }

    void Update()
    {
        duration += Time.deltaTime;
        if (duration >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
