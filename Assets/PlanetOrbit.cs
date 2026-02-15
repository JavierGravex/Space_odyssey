using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlanetOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float orbitAngularSpeed = 90f; // degrees/s
    public float minRadius = 1.5f;

    private void Reset()
    {
        Collider2D c = GetComponent<Collider2D>();
        c.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Movement m = other.GetComponent<Movement>();
        if (m != null)
        {
            m.EnterOrbit(transform, orbitAngularSpeed, minRadius);
        }
    }
}