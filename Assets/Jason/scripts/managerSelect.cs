using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class managerSelect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gamemodeText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject levelObject;
    private int gamemodeNumber;
    private int levelNumberFree;
    private int levelNumberRhythm;

    public void gamemodeChange(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 0:
                gamemodeNumber--;
                break;

            case 1:
                gamemodeNumber++;
                break;
        }

        switch (gamemodeNumber)
        {
            case -1:
                gamemodeNumber = 2;
                gamemodeText.text = "Rhythm";
                levelObject.SetActive(true);
                break;

            case 0:
                gamemodeText.text = "Campaign";
                levelObject.SetActive(false);
                break;

            case 1:
                gamemodeText.text = "Free Play";
                levelText.text = "Level: " + (levelNumberFree + 1);
                levelObject.SetActive(true);
                break;

            case 2:
                gamemodeText.text = "Rhythm";
                levelText.text = "Level: " + (levelNumberRhythm + 1);
                levelObject.SetActive(true);
                break;

            case 3:
                gamemodeNumber = 0;
                gamemodeText.text = "Campaign";
                levelObject.SetActive(false);
                break;
        }
    }
    public void levelChange(int buttonNumber)
    {
        switch (gamemodeNumber, buttonNumber)
        {
            case (1, 0):
                levelNumberFree--;

                switch (levelNumberFree)
                {
                    case -1:
                        levelNumberFree = 29;
                        break;
                }

                levelText.text = "Level: " + (levelNumberFree + 1);
                break;
            case (1, 1):
                levelNumberFree++;

                switch (levelNumberFree)
                {
                    case 30:
                        levelNumberFree = 0;
                        break;
                }

                levelText.text = "Level: " + (levelNumberFree + 1);
                break;


            case (2, 0):
                levelNumberRhythm--;

                switch (levelNumberRhythm)
                {
                    case -1:
                        levelNumberRhythm = 3;
                        break;
                }

                levelText.text = "Level: " + (levelNumberRhythm + 1);
                break;

            case (2, 1):
                levelNumberRhythm++;

                switch (levelNumberRhythm)
                {
                    case 4:
                        levelNumberRhythm = 0;
                        break;
                }

                levelText.text = "Level: " + (levelNumberRhythm + 1);
                break;
        }
    }

    public int getSelect()
    {
        switch (gamemodeNumber)
        {
            default:
                return 1;

            case 1:
                return levelNumberFree + 1;

            case 2:
                return ((levelNumberRhythm + 1) * 9) + 1;
        }
    }

    public int getMode()
    {
        return gamemodeNumber;
    }
}
