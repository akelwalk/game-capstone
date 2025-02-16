using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerMenu : MonoBehaviour
{
    [SerializeField] GameObject buttons_0;
    [SerializeField] GameObject settings_1;
    [SerializeField] GameObject credits_2;
    [SerializeField] Sprite[] menuSprites;
    private IEnumerator transformCoroutine1;
    private IEnumerator transformCoroutine2;
    private Vector2 menuTransform1;
    private Vector2 menuTransform2;
    private int menuButtonTransform1;
    private int menuButtonTransform2;
    private int menuButtonHeld;
    private bool sceneLoading;

    void Start()
    {
        menuButtonHeld = -1;
        transformCoroutine1 = transform1();
        transformCoroutine2 = transform2();
        menuTransform1 = new Vector2(0.44f, 0.44f);
        menuTransform2 = new Vector2(0.4f, 0.4f);
    }

    public void buttons1()
    {
        switch (menuButtonHeld)
        {
            case 0:
                SceneManager.LoadScene("default");
                sceneLoading = true;
                break;

            case 1:
                settings_1.SetActive(true);
                break;
            
            case 2:
                credits_2.SetActive(true);
                break;

            case 3:
                // sceneLoading = true; // Enable later during build
                Application.Quit();
                break;
        }
    }

    public void buttons2(int menuSelected)
    {
        if (menuButtonHeld == -1 || menuButtonHeld == menuSelected)
        {
            buttons_0.transform.GetChild(menuSelected).GetComponent<SpriteRenderer>().sprite = menuSprites[1];
        }
    }

    public void buttons3(int menuSelected)
    {
        if (menuButtonHeld == -1 || menuButtonHeld == menuSelected)
        {
            buttons_0.transform.GetChild(menuSelected).GetComponent<SpriteRenderer>().sprite = menuSprites[0];
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
}
