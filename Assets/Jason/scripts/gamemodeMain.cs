using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static managerMain;

public class gamemodeMain : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
    private int objectNumber;

    private void Start()
    {
        objectNumber = int.Parse(gameObject.name.Substring(0, 1));

        if (objectNumber == 6)
        {
            switch (PlayerPrefs.GetInt("arrowDifficulty"))
            {
                case 0:
                    gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Easy";
                    break;

                case 1:
                    gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Medium";
                    break;

                case 2:
                    gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Hard";
                    break;
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        switch (objectNumber)
        {
            case 0:
                managerCore.managerSelect.gamemodeChange(0);
                break;

            case 1:
                managerCore.managerSelect.gamemodeChange(1);
                break;

            case 4:
                switch (managerCore.managerSelect.getMode())
                {
                    case 0:
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 1);
                        break;

                    case 1:
                        MainManager.Instance.setLevel(managerCore.managerSelect.getSelect() - 1);
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 1);
                        break;        

                    case 2:
                        MainManager.Instance.setLevel(managerCore.managerSelect.getSelect() - 1);
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 3);
                        break;
                }
                break;

            case 6:
                PlayerPrefs.SetInt("arrowDifficulty", (PlayerPrefs.GetInt("arrowDifficulty") + 1) % 3);

                switch (PlayerPrefs.GetInt("arrowDifficulty"))
                {
                    case 0:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Easy";
                        break;

                    case 1:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Medium";
                        break;

                    case 2:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Hard";
                        break;
                }
                break;

            case 5:
                PlayerPrefs.SetInt("arrowDifficulty", PlayerPrefs.GetInt("arrowDifficulty") - 1);

                if (PlayerPrefs.GetInt("arrowDifficulty") == -1)
                {
                    PlayerPrefs.SetInt("arrowDifficulty", 2);
                }

                switch (PlayerPrefs.GetInt("arrowDifficulty"))
                {
                    case 0:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Easy";
                        break;

                    case 1:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Medium";
                        break;

                    case 2:
                        gameObject.transform.parent.gameObject.GetComponent<TextMeshProUGUI>().text = "Hard";
                        break;
                }
                break;
        }
    }
}
