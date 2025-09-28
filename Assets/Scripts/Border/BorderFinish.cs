using UnityEngine;
using UnityEngine.SceneManagement;
public class BorderFinish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FinishLevel();
        }
    }

    void FinishLevel()
    {
        Checkpoint.lastCheckpoint = new Vector3(-10, -3, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
