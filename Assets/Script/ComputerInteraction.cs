using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject uiPanel; //UI popup
    public GameObject interactionText;
    private bool isPlayerNearby = false;
    public bool isUIOpen = false; // UI ���� ���� ����

    void Start()
    {
        uiPanel.SetActive(false);
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && !isUIOpen) // �÷��̾ ������ �ְ� UI�� ���� ���� ������
        {
            interactionText.SetActive(true);
            interactionText.transform.position = transform.position + Vector3.up * 2f;

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                uiPanel.SetActive(true); // UI Ȱ��ȭ

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                PlayerController.canMove = false;

                isUIOpen = true; // UI�� ���� ���·� ����
            }
        }
        else if (!isUIOpen) // UI�� ���� ���� ������ interactionText ��Ȱ��ȭ
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

            // UI�� ���� ���� ������ interactionText�� ��Ȱ��ȭ
            if (!isUIOpen)
            {
                interactionText.SetActive(false);
            }
        }
    }

    // UI�� �ݴ� �޼���
    public void CloseUI()
    {
        uiPanel.SetActive(false);
        isUIOpen = false; // UI�� �������Ƿ� ���� ����

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.canMove = true;
    }
}
