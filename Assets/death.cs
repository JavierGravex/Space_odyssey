using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    public GameObject deathText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1"))
        {
            Die();
        }
    }

    void Die()
    {
        deathText.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0f;

    }
}
