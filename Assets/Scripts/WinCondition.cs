using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject winText; // Assign your "You Win!" UI object here in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        // This makes it so the script doesn't do anything when unchecked
        if (!this.enabled) 
        {
            return;
        }
        
        // Check if the object entering the trigger is the Player
        if (other.CompareTag("Player"))
        {
            Win(other.gameObject);
        }
    }

    void Win(GameObject player)
    {
        if (winText != null) winText.SetActive(true);
        
        Time.timeScale = 0f; // Stop the game logic
        player.SetActive(false); // Disable the player to prevent further movement
        Debug.Log("Mission Accomplished! Player reached the goal.");
    }
}