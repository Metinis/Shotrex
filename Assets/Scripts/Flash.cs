using UnityEngine;

public class Flash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void FlashSprite()
    {
        StartCoroutine(DoFlash());
    }

    private System.Collections.IEnumerator DoFlash()
    {
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true; 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
