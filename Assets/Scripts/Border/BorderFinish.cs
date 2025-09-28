using UnityEngine;
using UnityEngine.SceneManagement;
public class BorderFinish : MonoBehaviour
{
    public GameObject player;
    public GameObject winText;
    public float winScreenDuration = 4.0f;
    private bool won = false;
    private float duration = 0.0f;
    private Vector3 startPosition = new Vector3(-10, -3, 0);
    private Vector3 endPosition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FinishLevel();
        }
    }

    void FinishLevel()
    {
        won = true;
        endPosition = player.transform.position;
    }

    void FixedUpdate()
    {
        if (won)
        {
            duration += Time.fixedDeltaTime;
            if (duration >= winScreenDuration)
            {
                player.transform.position = endPosition;
                winText.SetActive(true);
                Checkpoint.lastCheckpoint = startPosition;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
