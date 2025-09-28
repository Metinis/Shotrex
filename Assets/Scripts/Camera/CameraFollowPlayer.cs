using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Collider2D targetCollider;
    void Start()
    {
        targetCollider = target.GetComponent<Collider2D>();
    }
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 followPoint;

        if (targetCollider != null)
        {
            followPoint = targetCollider.bounds.center;
        }
        else
        {
            followPoint = target.position;
        }
        
        if (followPoint.x > 0 && followPoint.y > -3)
        {
            transform.position = followPoint + offset;
        }
        else if (followPoint.y + offset.y > 2)
        {
            Vector3 pos = transform.position;
            pos.y = followPoint.y + offset.y;
            pos.z = offset.z;
            transform.position = pos;
        }
        else if (followPoint.x > 0)
        {
            Vector3 pos = transform.position;
            pos.x = followPoint.x + offset.x;
            pos.z = offset.z;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y = followPoint.y + offset.y;
            pos.z = offset.z;
            transform.position = pos;
        }
    }
}
