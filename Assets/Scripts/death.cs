using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. Logic for if THIS object is the Player
        if (gameObject.CompareTag("Player")) 
        {
            if (collision.gameObject.CompareTag("enemy1") || collision.gameObject.CompareTag("enemy2") || collision.gameObject.CompareTag("asteroid") )
            {
                PlayerDie();
            }
        }

        // 2. Logic for if THIS object is the Enemy
        if (gameObject.CompareTag("enemy2"))
        {
            // If enemy hits an obstacle, it just disappears without stopping time
            if (collision.gameObject.CompareTag("enemy1") || collision.gameObject.CompareTag("asteroid"))
            {
                EnemyDie();
            }
        }
    
    }

    void PlayerDie()
    {
        if (deathText != null) deathText.SetActive(true);
        Time.timeScale = 0f; // STOP the game only for the player
        gameObject.SetActive(false); 
    }

    void EnemyDie()
    {
        // Do NOT stop time here. Just remove the enemy.
        Debug.Log("Enemy crashed into an obstacle!");
        Destroy(gameObject); 
    }
}