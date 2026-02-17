using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera cam;
    private float objectWidth;

    void Start()
    {
        cam = Camera.main;
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        float halfCamWidth = cam.orthographicSize * cam.aspect;

        float minX = cam.transform.position.x - halfCamWidth + objectWidth;
        float maxX = cam.transform.position.x + halfCamWidth - objectWidth;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}
