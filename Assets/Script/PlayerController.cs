using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection;

    public static bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove) return;
        MovePlayer();
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal"); //A/D or Left/Right
        float v = Input.GetAxis("Vertical"); //W/S or Up/Down

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camForward * v + camRight * h).normalized;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
