using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathText;
    
    [Header("UI Reference")]
    public LivesUI livesManager; // NEW: The connection to your UI script

    private void Start()
    {
        Time.timeScale = 1f; // Ensure the game is running when the scene starts or restarts
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. Logic for if THIS object is the Player
        if (gameObject.CompareTag("Player")) 
        {
            if (collision.gameObject.CompareTag("enemy1") || collision.gameObject.CompareTag("enemy2") || collision.gameObject.CompareTag("asteroid") )
            {
                PlayerHit(); // Changed this to just take a hit instead of instant death
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

    void PlayerHit()
    {
        // 1. Check if we have the lives manager connected
        if (livesManager != null)
        {
            // 2. Tell the UI to subtract one life
            livesManager.LoseLife();
            
            // 3. Check if we are totally out of lives
            if (livesManager.currentLives <= 0)
            {
                GameOver();
            }
            else
            {
                // Player lost a life but is still alive!
                // (Eventually, you can add respawn or invincibility logic here)
                Debug.Log("Player hit! Lives remaining: " + livesManager.currentLives);
            }
        }
        else
        {
            // If you forgot to attach the LivesManager in Unity, default to instant death
            GameOver();
        }
    }

    void GameOver()
    {
        // This is your original PlayerDie logic
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