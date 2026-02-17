using UnityEngine;

public sealed class EnemyFollow : MonoBehaviour
{
    public Transform player; // Drag the Player object here in the Inspector
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

void Start()
    {
        // This searches the scene for the object tagged "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    void Update()
    {
        if (player == null) return;

        // 1. Calculate direction to the player
        Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
        direction.Normalize();

        // 2. Rotate to face the player
        // For most 2D sprites, 'transform.up' is the front of the ship
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 3. Move forward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}