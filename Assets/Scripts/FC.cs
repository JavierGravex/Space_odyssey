using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [Header("Follow")]
    public Transform playerShip;
    public float yOffset = 2f;
    public float fixedX = 0f;

    [Header("View")]
    public bool forceOrthographic = true;
    public bool useManualSize = true;
    public float orthographicSize = 9.8f;
    public bool autoFitWorldWidth = false;
    public float targetWorldWidth = 10f;
    


    private Camera cam;
    private float startY;

    


    void Start()
    {
        cam = GetComponent<Camera>();
        if (forceOrthographic)
        {
            cam.orthographic = true;
        }

        if (cam.orthographic)
        {
            if (autoFitWorldWidth && targetWorldWidth > 0f)
            {
                cam.orthographicSize = targetWorldWidth / (2f * cam.aspect);
            }
            else if (useManualSize)
            {
                cam.orthographicSize = orthographicSize;
            }
        }

        startY = transform.position.y;
    }

    void LateUpdate()
    {
        //Make sure the default camera size is what we set it
        if (useManualSize && cam.orthographicSize != orthographicSize)
        {
            cam.orthographicSize = orthographicSize;
        }
        if (playerShip == null) return;

        float targetY = playerShip.position.y + yOffset;
        if (targetY < startY)
        {
            targetY = startY;
        }
        transform.position = new Vector3(fixedX, targetY, -10f);
    }
}
