using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlanetOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float orbitAngularSpeed = 90f; // degrees/s
    public float minRadius = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check if it's the Player
        Movement m = other.GetComponent<Movement>();
        if (m != null)
        {
            m.EnterOrbit(transform, orbitAngularSpeed, minRadius);
            return; // Important: Stop here so we don't destroy the player!
        }

        // 2. Check if it's a Mine (enemy1) OR the Hunter (enemy2)
        if (other.CompareTag("enemy1") || other.CompareTag("enemy2"))
        {
            Debug.Log(other.gameObject.name + " destroyed by planet gravity!");
            Destroy(other.gameObject); 
        }
    }
}