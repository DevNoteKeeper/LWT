using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodManager : MonoBehaviour
{
    public static PodManager Instance { get; private set; }
    public bool IsInPod { get; private set; }

    private void Awake()
    {
        // 싱글턴 패턴 적용
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnterPod()
    {
        IsInPod = true;
        Debug.Log("Entered Pod");
    }

    public void ExitPod()
    {
        IsInPod = false;
        Debug.Log("Exited Pod");

        if (FreshAirManager.Instance != null)
        {
            FreshAirManager.Instance.ResetAir();
        }
    }
}
