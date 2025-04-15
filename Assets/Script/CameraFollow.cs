using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float mouseSensitivity = 3f;
    private float yaw = 0f;

    public float minYaw = -90f;
    public float maxYaw = 90f;

    public bool allowFullRotation = false;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        if (!allowFullRotation)
        {
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
        }

        Quaternion rotation = Quaternion.Euler(0, yaw, 0);
        Vector3 desirePosition = target.position + rotation * offset;

        transform.position = desirePosition;
        transform.LookAt(target);
    }
}
