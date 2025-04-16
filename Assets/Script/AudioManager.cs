using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private bool wasInPod = false;

    // Start is called before the first frame update
    void Start()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = GetComponent<AudioSource>();
        }

        // ó�� ������ �� Pod�� ���� �ʴٸ� ������ ���
        if (backgroundMusic != null && !PodManager.Instance.IsInPod)
        {
            backgroundMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PodManager.Instance == null) return; // PodManager�� ���� �������� �ʾҴٸ� �ƹ� �͵� �� ��

        bool isInPod = PodManager.Instance.IsInPod;

        if (isInPod && !wasInPod)
        {
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause();
                Debug.Log("Music paused inside pod");
            }
        }

        if (!isInPod && wasInPod)
        {
            if (backgroundMusic != null && !backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
                Debug.Log("Music resumed outside pod");
            }
        }

        wasInPod = isInPod;
    }
}
