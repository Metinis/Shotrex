using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject particleSystem;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (particleSystem != null)
            {
                particleSystem.transform.position = transform.position;
                particleSystem.SetActive(true);
                particleSystem.GetComponent<ParticleSystem>().Play();
            }
            if (powerUp != null)
            {
                Instantiate(powerUp, transform.position, Quaternion.identity);
            }
            GetComponent<RetroSound>().PlayBoxBreak();
            Destroy(gameObject);
        }
    }
}
