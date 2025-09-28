using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (target.position.x > 0 && target.position.y > -3)
        {
            transform.position = target.position + offset;
        }
        else if(target.position.y > 2)
        {
            Vector3 pos = transform.position;
            pos.y = target.position.y + offset.y;
            pos.z = offset.z;
            transform.position = pos;
        }
        else if(target.position.x > 0)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x + offset.x;
            pos.z = offset.z;
            transform.position = pos;
        }
        
    }
}
