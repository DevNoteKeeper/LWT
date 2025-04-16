using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodDoorController : MonoBehaviour
{

    public Transform leftDoor;
    public Transform rightDoor;

    public float openAngleX = -90f;
    public float doorSpeed = 2f;

    private bool isOpen = false;
    private bool isPlayerInside = false;

    private Quaternion leftClosedRot;
    private Quaternion rightClosedRot;

    private Quaternion leftOpenRot;
    private Quaternion rightOpenRot;

    void Start()
    {
        leftClosedRot = leftDoor.localRotation;
        rightClosedRot = rightDoor.localRotation;

        leftOpenRot = Quaternion.Euler(openAngleX, 0f, 0f) * leftClosedRot;
        rightOpenRot = Quaternion.Euler(openAngleX, 0f, 0f) * rightClosedRot;
    }


    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Player detected");
            isOpen = true;
        }

        if (isOpen)
        {
            leftDoor.localRotation = Quaternion.Slerp(leftDoor.localRotation, leftOpenRot, Time.deltaTime * doorSpeed);
            rightDoor.localRotation = Quaternion.Slerp(rightDoor.localRotation, rightOpenRot, Time.deltaTime * doorSpeed);
        }
        else
        {
            leftDoor.localRotation = Quaternion.Slerp(leftDoor.localRotation, leftClosedRot, Time.deltaTime * doorSpeed);
            rightDoor.localRotation = Quaternion.Slerp(rightDoor.localRotation, rightClosedRot, Time.deltaTime * doorSpeed);
        }
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            CloseDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
