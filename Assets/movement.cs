// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     private Vector2 movement;
//     private Rigidbody2D rb;

//     void Start()
//     {
//         // Get the Rigidbody2D component attached to the player
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         // Get input (WASD or Arrow keys)
//         // Returns a value between -1 and 1
//         movement.x = Input.GetAxisRaw("Horizontal");
//         movement.y = Input.GetAxisRaw("Vertical");
//     }

//     void FixedUpdate()
//     {
//         // Move the player based on the input and speed
//         rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
//     }
// }

using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Fuel Settings")]
    public float maxFuel = 100f; // Total Fuel
    public float currentFuel = 100f; // Current Fuel (Updated)
    public float fuelBurnRate = 3f; // Fuel burn rate when moving forward or back
    public float turnFuelCost = 1f; // Fuel burn when turning

    [Header("Speed Settings")]
    public float maxSpeed = 5f;        // Fastest speed possible
    public float acceleration = 2f;    // How fast you build up speed
    public float deceleration = 1f;    // How fast you slow down when letting go
    public float rotationSpeed = 50f; // How fast you turn

    [Header("Orbit")]
    public bool isOrbiting;
    private Transform orbitCenter;
    private float orbitRadius;
    private float orbitAngleDeg;
    private float orbitAngularSpeedDeg;

    // Private variable to track current momentum
    private float currentSpeed = 0f;

    public void EnterOrbit(Transform center, float angularSpeedDeg, float minRadius)
    {
        if (center == null) return;

        orbitCenter = center;
        orbitAngularSpeedDeg = angularSpeedDeg;

        Vector2 fromCenter = (Vector2)transform.position - (Vector2)orbitCenter.position;
        orbitRadius = Mathf.Max(fromCenter.magnitude, minRadius);

        orbitAngleDeg = Mathf.Atan2(fromCenter.y, fromCenter.x) * Mathf.Rad2Deg;
        isOrbiting = true;
    }

    public void ExitOrbit(bool launchAtMaxSpeed)
    {
        if (!isOrbiting) return;

        Vector2 radial = ((Vector2)transform.position - (Vector2)orbitCenter.position).normalized;
        Vector2 tangent = orbitAngularSpeedDeg >= 0f
            ? new Vector2(-radial.y, radial.x)
            : new Vector2(radial.y, -radial.x);

        transform.up = tangent;

        if (launchAtMaxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        isOrbiting = false;
        orbitCenter = null;
    }



    void Update()
    {
        //If it's orbiting then follow this instead
        if (isOrbiting && orbitCenter != null)
        {
            orbitAngleDeg += orbitAngularSpeedDeg * Time.deltaTime;

            float rad = orbitAngleDeg * Mathf.Deg2Rad;
            Vector2 radial = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            Vector2 center = orbitCenter.position;
            Vector2 p = center + radial * orbitRadius;
            transform.position = p;

            Vector2 tangent = orbitAngularSpeedDeg >= 0.01f
                ? new Vector2(-radial.y, radial.x)   
                : new Vector2(radial.y, -radial.x);  
                
            transform.up = tangent;
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
            {
                ExitOrbit(true);
            }

            return;
        }
        // Turning Left/Right
        float turnInput = Input.GetAxis("Horizontal");
        if (turnInput != 0 && currentFuel > 0)
        {
            // 1. Do the rotation
            transform.Rotate(0, 0, -turnInput * rotationSpeed * Time.deltaTime);

            // 2. Burn the fuel (using the cheaper rate)
            currentFuel -= turnFuelCost * Time.deltaTime;
        }


        // Forward Momentum
        if (Input.GetAxis("Vertical") > 0 && currentFuel > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentFuel -= fuelBurnRate * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0 && currentFuel > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            currentFuel -= fuelBurnRate * Time.deltaTime;
        }   

        // Never let speed fuel go over their max. 
        // Speed can go reverse up to -2, fuel can't go under 0
        currentSpeed = Mathf.Clamp(currentSpeed, -2, maxSpeed);

        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

        // Apply the Movement
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }
}