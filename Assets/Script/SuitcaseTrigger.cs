using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseTrigger : MonoBehaviour
{
    public string podType;
    public GameObject podLabel;
    public GameObject warningUI;
    public Vector3 offsetAboveHead = new Vector3(0, 2f, 0);

    private bool playerInside = false;
    private bool isCarrying = false;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        podLabel.SetActive(false);
        warningUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (PlayerInfoManager.isInfoSubmitted)
            {
                podLabel.SetActive(true);
            }
            else
            {
                warningUI.SetActive(true);
            }
        }
        player = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            podLabel.SetActive(false);
            warningUI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInside && PlayerInfoManager.isInfoSubmitted)
        {
            if (PlayerInfoManager.selectedGenderType == podType && Input.GetKeyDown(KeyCode.G))
            {
                isCarrying = true;
                Debug.Log("Suitcase picked up");
            }
        }

        if (isCarrying && player != null)
        {
            transform.position = player.position + offsetAboveHead;
        }
    }
}
