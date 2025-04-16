using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PodManager.Instance.EnterPod();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PodManager.Instance.ExitPod();
        }
    }
}
