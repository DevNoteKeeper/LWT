using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodInstallPoint : MonoBehaviour
{
    public PodPoint.PodType allowedPodType;
    public GameObject visualEffect;
    public GameObject gKeyUI;
    public GameObject suitcase;
    public GameObject pod;

    private bool playerNearby = false;
    private Transform player;
    public SuitcaseTrigger suitcaseTrigger;
    // Start is called before the first frame update
    void Start()
    {
        visualEffect.SetActive(false);
        gKeyUI.SetActive(false);
        suitcaseTrigger = suitcase.GetComponent<SuitcaseTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        if (PlayerInfoManager.isInfoSubmitted)
        {
            if (PlayerInfoManager.selectedPodType.Contains(allowedPodType.ToString()) == true)
            {
                visualEffect.SetActive(true);
                gKeyUI.SetActive(true);
                playerNearby = true;
            }
        }
        else
        {
            Debug.LogWarning("Information not submitted yet");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        visualEffect.SetActive(false);
        gKeyUI.SetActive(false);
        playerNearby = false;
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.G))
        {
            InstallPod();
        }
    }

    private void InstallPod()
    {
        Destroy(suitcase);
        Instantiate(pod, transform.position, Quaternion.identity);

        Debug.Log("Pod installed");

        visualEffect.SetActive(false);
        gKeyUI.SetActive(false);
    }
}
