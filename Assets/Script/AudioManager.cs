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

        // 처음 시작할 때 Pod에 있지 않다면 음악을 재생
        if (backgroundMusic != null && !PodManager.Instance.IsInPod)
        {
            backgroundMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PodManager.Instance == null) return; // PodManager가 아직 생성되지 않았다면 아무 것도 안 함

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
