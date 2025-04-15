using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerSettings : MonoBehaviour
{
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSounds;
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioSounds;

    private void Start()
    {
        switch (PlayerPrefs.HasKey("audioMusic"))
        {
            case true:
                sliderMusic.value = PlayerPrefs.GetInt("audioMusic");
                sliderSounds.value = PlayerPrefs.GetInt("audioSounds");
                break;

            case false:
                PlayerPrefs.SetInt("audioMusic", 10);
                PlayerPrefs.SetInt("audioSounds", 14);
                sliderMusic.value = 10;
                sliderSounds.value = 14;
                break;
        }

        audioMusic.volume = (sliderMusic.value / 20f);
        sliderMusic.onValueChanged.AddListener(delegate { slider1(); });

        audioSounds.volume = (sliderSounds.value / 20f);
        sliderSounds.onValueChanged.AddListener(delegate { slider2(); });

        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void fullscreen(bool toggleValue)
    {
        Screen.fullScreen = toggleValue;
    }

    private void slider1()
    {
        audioMusic.volume = (sliderMusic.value / 20f);
        PlayerPrefs.SetInt("audioMusic", (int) (audioMusic.volume * 20));
    }

    private void slider2()
    {
        audioSounds.volume = (sliderSounds.value / 20f);
        PlayerPrefs.SetInt("audioSounds", (int)(audioSounds.volume * 20));
    }
}
