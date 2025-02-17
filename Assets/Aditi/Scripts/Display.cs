using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor;

public class Display : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text scoreText;

    void Update() {
        if (levelText != null) {
            LevelDisplay();
        }
        if (scoreText != null) {
            ScoreDisplay();
        }
        
    }

    public void LevelDisplay() {
        levelText.text = "Level: " + (MainManager.Instance.getLevel() + 1);
    }

    public void ScoreDisplay() {
        scoreText.text = "Score: " + MainManager.Instance.getScore();
    }

}
