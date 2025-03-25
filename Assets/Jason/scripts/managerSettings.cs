using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerSettings : MonoBehaviour
{
    [SerializeField] Slider sliderMusic;
    [SerializeField] AudioSource audioMusic;

    private void Start()
    {
        sliderMusic.value = 14;
        audioMusic.volume = (sliderMusic.value / 20f);
        sliderMusic.onValueChanged.AddListener(delegate { slider1(); });
    }

    public void fullscreen(bool toggleValue)
    {
        Screen.fullScreen = toggleValue;
    }

    private void slider1()
    {
        audioMusic.volume = (sliderMusic.value / 20f);
    }
}
