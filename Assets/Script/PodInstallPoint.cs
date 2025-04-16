using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodInstallPoint : MonoBehaviour
{
    public PodPoint.PodType allowedPodType;
    public GameObject visualEffect;
    public GameObject installUI;
    public GameObject uninstallUI;
    public GameObject pod;

    public bool isInstallPod = false;

    private bool playerNearby = false;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        visualEffect.SetActive(true);
        installUI.SetActive(false);
        uninstallUI.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        player = other.transform;
        if (PlayerInfoManager.isInfoSubmitted)
        {
            string playerPod = PlayerInfoManager.selectedPodType.ToLower();
            string requiredPod = allowedPodType.ToString().ToLower();

            Debug.Log($"PlayerPod: {playerPod}, RequiredPod: {requiredPod}");

            if (!isInstallPod)
            {
                visualEffect.SetActive(false);
                installUI.SetActive(true);
                installUI.transform.position = transform.position + Vector3.up * 0.7f;
                if(playerPod == requiredPod)
                {
                    playerNearby = true;
                }
                
            }
            else {
                uninstallUI.SetActive(true);
                uninstallUI.transform.position = transform.position + Vector3.up * 0.7f;
                visualEffect.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Information not submitted yet");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isInstallPod) {
            installUI.SetActive(false);
            playerNearby = false;
            visualEffect.SetActive(true);
        }
        else
        {
            uninstallUI.SetActive(false);
            visualEffect.SetActive(false);
        }
        
    }


    private void Update()
    {

        if (playerNearby && Input.GetKeyDown(KeyCode.G) && !isInstallPod)
        {
            InstallPod();
        }

        if (isInstallPod && playerNearby && Input.GetKeyDown(KeyCode.U))
        {
            UninstallPod();
        }
    }

    private void InstallPod()
    {
        visualEffect.SetActive(false);
        SuitcaseTrigger[] suitcaseTriggers = player.GetComponentsInChildren<SuitcaseTrigger>();
        SuitcaseTrigger carriedSuitcaseTrigger = null;

        foreach (SuitcaseTrigger trigger in suitcaseTriggers)
        {
            if (trigger.isCarrying)
            {
                carriedSuitcaseTrigger = trigger;
                break;
            }
        }

        if (carriedSuitcaseTrigger != null)
        {
            GameObject suitcaseObj = carriedSuitcaseTrigger.gameObject;
            carriedSuitcaseTrigger.transform.SetParent(null);
            Destroy(suitcaseObj);
            Debug.Log("Suitcase destroyed");
        }
        else
        {
            Debug.Log("No carried suitcase found");
            return;
        }

        Vector3 installPosition = new Vector3(2, -6.14f, transform.position.z);
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);
        Instantiate(pod, installPosition, rotation);
        Debug.Log($"Pod installed at {installPosition}");

        isInstallPod = true;

        visualEffect.SetActive(false);
        installUI.SetActive(false);
        uninstallUI.SetActive(true);
        uninstallUI.transform.position = transform.position + Vector3.up * 0.7f;
    }

    private void UninstallPod()
    {
        GameObject existingPod = GameObject.FindWithTag("Pod");
        if (existingPod != null)
        {
            Destroy(existingPod);
            Debug.Log("Pod uninstalled");

            isInstallPod = false;

            uninstallUI.SetActive(false);
            installUI.SetActive(true);
            installUI.transform.position = transform.position + Vector3.up * 0.7f;
            visualEffect.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No pod found to uninstall");
        }
    }
}
