using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Transform pointA; // Drag "Left Edge" object here
    public Transform pointB; // Drag "Right Edge" object here
    public float speed = 5f;
    
    private Transform currentTarget;

    void Start()
    {
        // Start by moving toward Point B
        currentTarget = pointB;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

        // Check if we are close enough to the target to switch
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // If we were going to B, go to A. Otherwise, go to B.
            if (currentTarget == pointB) {
                currentTarget = pointA;
            } else {
                currentTarget = pointB;
            }
        }
    }
}