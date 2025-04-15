using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject uiPanel; //UI popup
    private bool isPlayerNearby = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            uiPanel.SetActive(true); //active UI
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            uiPanel.SetActive(false); //close UI
        }
        {

        }
    }
}
