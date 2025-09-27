using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 3f;
    private float duration = 0.0f;
    void FixedUpdate()
    {
        transform.Translate(Time.fixedDeltaTime * speed * transform.right);
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
