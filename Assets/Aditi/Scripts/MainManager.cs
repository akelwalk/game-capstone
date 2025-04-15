using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private int score = 0;
    private int level = 0;
    public bool success = true;
    public bool transitionStop;
    public bool levelEnd = false;

    private AudioSource audioSource;


    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {

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

    public void playMusic(AudioClip clip) {
        if (!audioSource.isPlaying) {
            audioSource.clip = clip; 
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void stopMusic() {
        audioSource.Stop();
    }

    public void increaseLevel() {
        level++;
    }

    public void setLevel(int level) {
        this.level = level;
    }

    public int getLevel() {
        return level;
    }

    public int getScore() {
        return score;
    }
}