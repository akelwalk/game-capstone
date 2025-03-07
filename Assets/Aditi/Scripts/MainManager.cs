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

    public void increaseLevel() {
        level++;
    }

    public int getLevel() {
        return level;
    }

    public int getScore() {
        return score;
    }

}
