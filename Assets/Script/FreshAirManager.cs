using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreshAirManager : MonoBehaviour
{
    public static FreshAirManager Instance { get; private set; }


    public Slider freshAirSlider;
    public float maxAir = 100f;
    public float currentAir;
    public float airDecreaseRate = 5f;
    public Image fillImage;

    public bool isInPod = false;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAir = maxAir;
        freshAirSlider.maxValue = maxAir;
        freshAirSlider.value = maxAir;
    }

    // Update is called once per frame
    void Update()
    {
        if (PodManager.Instance.IsInPod)
        {
            currentAir -= airDecreaseRate * Time.deltaTime;
            currentAir = Mathf.Clamp(currentAir, 0f, maxAir);
            freshAirSlider.value = currentAir;

            if(currentAir <= 0f)
            {
                Debug.Log("Air depleted!");
            }

            if (currentAir <= 20f)
            {
                fillImage.color = Color.red;
            }
            else
            {
                fillImage.color = new Color(68f / 255f, 33f / 255f, 1f);
            }
        }
    }

    public void ResetAir()
    {
        currentAir = maxAir;
        freshAirSlider.value = currentAir;
    }
}
