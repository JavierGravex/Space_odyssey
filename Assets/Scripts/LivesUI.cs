using UnityEngine;
using System.Collections.Generic;

public class LivesUI : MonoBehaviour
{
    [Header("References")]
    public Transform livesContainer;
    public GameObject lifePrefab;

    [Header("Life Settings")]
    public int startingLives = 3;
    public int currentLives;

    private List<GameObject> lifeIcons = new List<GameObject>();

    void Start()
    {
        // Give the player their starting lives and draw them immediately
        currentLives = startingLives;
        RedrawLives();
    }

    // Your death.cs script will call this method
    public void LoseLife()
    {
        currentLives--;
        
        // Prevent negative lives
        if (currentLives < 0) 
        {
            currentLives = 0;
            // You could eventually trigger a Game Over screen here!
        }
        
        RedrawLives();
    }

    // Ready for when you add health pickups later!
    public void AddLife()
    {
        currentLives++;
        RedrawLives();
    }

    // This handles the copy/pasting of the icons
    private void RedrawLives()
    {
        // 1. Clear out old icons
        foreach (GameObject icon in lifeIcons)
        {
            Destroy(icon);
        }
        lifeIcons.Clear();

        // 2. Create new icons for the current number of lives
        for (int i = 0; i < currentLives; i++)
        {
            GameObject newLife = Instantiate(lifePrefab, livesContainer);
            lifeIcons.Add(newLife);
        }
    }
}