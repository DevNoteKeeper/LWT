using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitcaseTrigger : MonoBehaviour
{
    public string podType;
    public GameObject podLabel;
    public GameObject warningUI;
    public Vector3 offsetAboveHead = new Vector3(0, 1f, 0);

    private bool playerInside = false;
    public bool isCarrying = false;
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
            player = other.transform;


            if (PlayerInfoManager.isInfoSubmitted)
            {
                podLabel.SetActive(true);
                podLabel.transform.position = transform.position + Vector3.up * 2f;
                warningUI.SetActive(false);
            }
            else
            {
                podLabel.SetActive(false);
                warningUI.SetActive(true);
                warningUI.transform.position = transform.position + Vector3.up * 2f;
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
            if (PlayerInfoManager.selectedPodType == podType && Input.GetKeyDown(KeyCode.G))
            {
                isCarrying = true;
                transform.SetParent(player);
                transform.localPosition = offsetAboveHead;
                Debug.Log("Suitcase picked up and parented to player");
            }
        }
    }
}
