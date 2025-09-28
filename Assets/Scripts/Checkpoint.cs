using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 lastCheckpoint = new Vector3(-10, -3, 0);

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpoint;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lastCheckpoint = transform.position;
        }
    }
}
