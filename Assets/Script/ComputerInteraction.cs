using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject uiPanel; //UI popup
    public GameObject interactionText;
    private bool isPlayerNearby = false;
    public bool isUIOpen = false; // UI 상태 추적 변수

    void Start()
    {
        uiPanel.SetActive(false);
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && !isUIOpen) // 플레이어가 가까이 있고 UI가 열려 있지 않으면
        {
            interactionText.SetActive(true);
            interactionText.transform.position = transform.position + Vector3.up * 2f;

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                uiPanel.SetActive(true); // UI 활성화

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                PlayerController.canMove = false;

                isUIOpen = true; // UI가 열린 상태로 설정
            }
        }
        else if (!isUIOpen) // UI가 열려 있지 않으면 interactionText 비활성화
        {
            interactionText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone!");
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // UI가 열려 있지 않으면 interactionText를 비활성화
            if (!isUIOpen)
            {
                interactionText.SetActive(false);
            }
        }
    }

    // UI를 닫는 메서드
    public void CloseUI()
    {
        uiPanel.SetActive(false);
        isUIOpen = false; // UI가 닫혔으므로 상태 변경

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.canMove = true;
    }
}
