using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.IO;

public class managerMenu : MonoBehaviour
{
    [SerializeField] Color32[] colorsUI;
    [SerializeField] GameObject buttons_0;
    [SerializeField] GameObject startSelect_0;
    [SerializeField] GameObject settings_1;
    [SerializeField] GameObject credits_2;
    [SerializeField] GameObject menuBackground;
    private Vector2 originalPosition;
    [SerializeField] Sprite[] menuSprites;
    private IEnumerator transformCoroutine1;
    private IEnumerator transformCoroutine2;
    private Vector2 menuTransform1;
    private Vector2 menuTransform2;
    private int menuButtonTransform1;
    private int menuButtonTransform2;
    private int menuButtonHeld;
    private bool sceneLoading;
    private byte transitionAlpha;
    [SerializeField] SpriteRenderer transitionMain;
    private Color32 transitionColor;
    [SerializeField] GameObject transitionObject;

    void Start()
    {
        menuButtonHeld = -1;
        transformCoroutine1 = transform1();
        transformCoroutine2 = transform2();
        menuTransform1 = new Vector2(0.44f, 0.44f);
        menuTransform2 = new Vector2(0.4f, 0.4f);
        originalPosition = Vector2.zero;
        transitionColor = new Color32(255, 255, 255, 0);
    }

    private void FixedUpdate()
    {
        switch (Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height)
        {
            case ( >= 0 and <= 1, >= 0 and <= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(Input.mousePosition.x / (Screen.width * 4) + 0.25f, Input.mousePosition.y / (Screen.height * 4) - 0.25f) + (originalPosition / 2), 0.225f);
                break;

            case ( >= 0 and <= 1, <= 0):  // the ones that are out of bounds in one corner
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2((Input.mousePosition.x / (Screen.width * 4) + 0.25f) + (originalPosition.x / 2), -0.255f), 0.225f);
                break;

            case ( >= 0 and <= 1, >= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2((Input.mousePosition.x / (Screen.width * 4) + 0.25f) + (originalPosition.x / 2), 0), 0.225f);
                break;

            case ( <= 0, >= 0 and <= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.25f, (Input.mousePosition.y / (Screen.height * 4) - 0.25f) + (originalPosition.y / 2)), 0.225f);
                break;

            case ( >= 1, >= 0 and <= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.5f, (Input.mousePosition.y / (Screen.height * 4) - 0.25f) + (originalPosition.y / 2)), 0.225f);
                break;

            case ( <= 0, <= 0): // the ones that are out of bounds in both corners
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.25f, -0.255f), 0.225f);
                break;

            case ( <= 0, >= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.25f, 0), 0.225f);
                break;

            case ( >= 1, <= 0):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.5f, -0.255f), 0.225f);
                break;

            case ( >= 1, >= 1):
                menuBackground.transform.position = Vector2.Lerp(menuBackground.transform.position, new Vector2(0.5f, 0), 0.225f);
                break;
        }
    }

    public void buttons1()
    {
        switch (menuButtonHeld)
        {
            case 0:
                startSelect_0.SetActive(true);
                sceneLoading = true;
                break;

            case 1:
                settings_1.SetActive(true);
                break;
            
            case 2:
                credits_2.SetActive(true);
                break;

            case 3:
                Application.Quit();
                break;
        }
    }

    public void buttons2(int menuSelected)
    {
        if (menuButtonHeld == -1 || menuButtonHeld == menuSelected)
        {
            buttons_0.transform.GetChild(menuSelected).GetComponent<SpriteRenderer>().sprite = menuSprites[1];
            buttons_0.transform.GetChild(menuSelected).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            buttons_0.transform.GetChild(menuSelected).GetChild(0).GetComponent<TextMeshProUGUI>().fontMaterial.DisableKeyword("UNDERLAY_ON");
        }
    }

    public void buttons3(int menuSelected)
    {
        if (menuButtonHeld == -1 || menuButtonHeld == menuSelected)
        {
            buttons_0.transform.GetChild(menuSelected).GetComponent<SpriteRenderer>().sprite = menuSprites[0];
            buttons_0.transform.GetChild(menuSelected).GetChild(0).GetComponent<TextMeshProUGUI>().color = colorsUI[0];
            buttons_0.transform.GetChild(menuSelected).GetChild(0).GetComponent<TextMeshProUGUI>().fontMaterial.EnableKeyword("UNDERLAY_ON");
        }
    }

    public void buttons4(int menuSelected)
    {
        menuButtonHeld = menuSelected;
        menuButtonTransform1 = menuButtonHeld;
        StartCoroutine(transformCoroutine1);
    }

    public void buttons5()
    {
        if (sceneLoading == false)
        {
            menuButtonTransform2 = menuButtonHeld;
            StartCoroutine(transformCoroutine2);
            menuButtonHeld = -1;
        }
    }

    IEnumerator transform1()
    {
        while (true)
        {
            buttons_0.transform.GetChild(menuButtonTransform1).localScale = Vector2.Lerp(buttons_0.transform.GetChild(menuButtonTransform1).localScale, menuTransform1, 0.35f);
            yield return new WaitForSeconds(1 / 60f);

            if (buttons_0.transform.GetChild(menuButtonTransform1).localScale.x >= 0.4999)
            {
                buttons_0.transform.GetChild(menuButtonTransform1).localScale = new Vector2(0.5f, 0.5f);
                StopCoroutine(transformCoroutine1);
            }

            if (menuButtonHeld == -1)
            {
                StopCoroutine(transformCoroutine1);
            }
        }
    }

    IEnumerator transform2()
    {
        while (true)
        {
            buttons_0.transform.GetChild(menuButtonTransform2).localScale = Vector2.Lerp(buttons_0.transform.GetChild(menuButtonTransform2).localScale, menuTransform2, 0.35f);
            yield return new WaitForSeconds(1 / 60f);

            if (buttons_0.transform.GetChild(menuButtonTransform2).localScale.x <= 0.4001)
            {
                buttons_0.transform.GetChild(menuButtonTransform2).localScale = new Vector2(0.4f, 0.4f);
                StopCoroutine(transformCoroutine2);
            }
        }
    }

    /* IEnumerator transition1()
    {
        while (true)
        {
            if (transitionAlpha == 255)
            {
                break;
            }

            transitionAlpha += 5;
            transitionColor.a = transitionAlpha;
            transitionMain.color = transitionColor;

            yield return new WaitForSeconds(1 / 60f);
        }

        yield return new WaitForSeconds(0.4f);

        SceneManager.LoadScene(1);
    } 


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            string[] stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2A.txt");
            {
                for (int x = 0; x < stageTimings.Length; x++)
                {
                    stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
                }
            }

            File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2A.txt", stageTimings);

            stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2B.txt");
            {
                for (int x = 0; x < stageTimings.Length; x++)
                {
                    stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
                }
            }

            File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2B.txt", stageTimings);

            stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2C.txt");
            {
                for (int x = 0; x < stageTimings.Length; x++)
                {
                    stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
                }
            }

            File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2C.txt", stageTimings);

            stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2D.txt");
            {
                for (int x = 0; x < stageTimings.Length; x++)
                {
                    stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
                }
            }

            File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2D.txt", stageTimings);
        }
    } */

}
