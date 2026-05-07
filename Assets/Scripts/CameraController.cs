using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [Header("Top-Down")]
    public float topDownHeight = 20f;
    public float topDownFOV = 60f;

    [Header("Third-Person")]
    public float tpOffset = 7f;
    public float tpHeight = 3f;
    public float tpFOV = 70f;

    [Header("Blend")]
    public float scrollSensitivity = 0.15f;
    public float followSpeed = 8f;

    private float _blend = 0f; // 0 = top-down, 1 = third-person
    private Camera _cam;

    void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        _blend = Mathf.Clamp01(_blend + scroll * scrollSensitivity);

        // Top-down state
        Vector3 tdPos = target.position + Vector3.up * topDownHeight;
        Quaternion tdRot = Quaternion.Euler(90f, 0f, 0f);

        // Third-person state: behind and slightly above the player
        Vector3 tpOffset3 = target.rotation * new Vector3(0f, tpHeight, -tpOffset);
        Vector3 tpPos = target.position + tpOffset3;
        Quaternion tpRot = Quaternion.LookRotation(
            (target.position + Vector3.up * 1f) - tpPos);

        Vector3 desiredPos = Vector3.Lerp(tdPos, tpPos, _blend);
        Quaternion desiredRot = Quaternion.Slerp(tdRot, tpRot, _blend);

        transform.position = Vector3.Lerp(transform.position, desiredPos,
            followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot,
            followSpeed * Time.deltaTime);

        _cam.fieldOfView = Mathf.Lerp(topDownFOV, tpFOV, _blend);
    }
}
