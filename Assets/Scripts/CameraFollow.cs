using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Smooth Settings")]
    public float smoothX = 0.08f;
    public float smoothY = 0.25f;
    public float verticalThreshold = 1.5f;

    [Header("Camera Bounds")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private float fixedY;
    private float velocityX;
    private float velocityY;

    private float cameraHalfHeight;
    private float cameraHalfWidth;

    void Start()
    {
        fixedY = transform.position.y;

        cameraHalfHeight = Camera.main.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float targetX = Mathf.SmoothDamp(
            transform.position.x,
            target.position.x,
            ref velocityX,
            smoothX
        );

        float heightDifference = Mathf.Abs(target.position.y - fixedY);

        if (heightDifference > verticalThreshold)
        {
            fixedY = Mathf.SmoothDamp(
                transform.position.y,
                target.position.y,
                ref velocityY,
                smoothY
            );
        }

        // Clamp with camera size considered
        float clampedX = Mathf.Clamp(
            targetX,
            minBounds.x + cameraHalfWidth,
            maxBounds.x - cameraHalfWidth
        );

        float clampedY = Mathf.Clamp(
            fixedY,
            minBounds.y + cameraHalfHeight,
            maxBounds.y - cameraHalfHeight
        );

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}