using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform doorMesh;
    public Vector3 openPositionOffset = new Vector3(2, 0, 0);
    public float openSpeed = 2f;
    public Collider wallCollider;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isPlayerNear = false;
    private bool isOpen = false;

    void Start()
    {
        closedPos = doorMesh.localPosition;
        openPos = closedPos + openPositionOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            StopAllCoroutines();
            StartCoroutine(OpenDoor());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            StopAllCoroutines();
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpen = true;
        wallCollider.enabled = false;


        while (Vector3.Distance(doorMesh.localPosition, openPos) > 0.01f)
        {
            float newX = Mathf.Lerp(doorMesh.localPosition.x, openPos.x, Time.deltaTime * openSpeed);
            doorMesh.localPosition = new Vector3(newX, closedPos.y, closedPos.z);
            yield return null;
        }
        doorMesh.localPosition = openPos;
    }

    IEnumerator CloseDoor()
    {
        isOpen = false;

        while (Mathf.Abs(doorMesh.localPosition.x - closedPos.x) > 0.01f)
        {
            float newX = Mathf.Lerp(doorMesh.localPosition.x, closedPos.x, Time.deltaTime * openSpeed);
            doorMesh.localPosition = new Vector3(newX, closedPos.y, closedPos.z);
            yield return null;
        }

        doorMesh.localPosition = closedPos;

        wallCollider.enabled = true;
    }


}
