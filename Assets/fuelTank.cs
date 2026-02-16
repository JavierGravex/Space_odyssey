using UnityEngine;

public class fuelTank : MonoBehaviour
{
    void Update()
{
    // Slowly rotate the tank
    transform.Rotate(0, 0, 50 * Time.deltaTime);
}

    public float fuelAmount = 25f; // How much fuel it gives

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hitting the tank is the Player
        if (other.CompareTag("Player"))
        {
            // Try to get the movement script from the player
            Movement playerMovement = other.GetComponent<Movement>();

            if (playerMovement != null)
            {
                playerMovement.AddFuel(fuelAmount);
                
                // Optional: Play a sound or effect here
                
                Destroy(gameObject); // Remove the tank from the game
            }
        }
    }
}