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

        if (!PodManager.Instance.IsInPod)
        {
            backgroundMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isInPod = PodManager.Instance.IsInPod;

        if (isInPod && !wasInPod)
        {
            if (backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause(); // ¶Ç´Â Stop()
            }
        }

        if (!isInPod && wasInPod)
        {
            if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
            }
        }

        wasInPod = isInPod;

    }
}
