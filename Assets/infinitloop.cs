using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float backgroundWidth; // Set this in the Inspector to the width of your sprite

    void Update()
    {
        // Move the background
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Check if the background has moved off-screen and reposition it
        if (transform.position.x < -backgroundWidth)
        {
            transform.Translate(Vector3.right * backgroundWidth * 2);
        }
    }
}