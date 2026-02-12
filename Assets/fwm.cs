using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;

    void Start()
    {
        // Use the camera as the boundary
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Half the width of the ship (So half the ship isn't off screen)
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void LateUpdate()
    {
        // Where the Ship is
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + objectWidth, screenBounds.x - objectWidth);

        // New Position
        transform.position = viewPos;
    }
}