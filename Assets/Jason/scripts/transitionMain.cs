using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionMain : MonoBehaviour
{

    private byte transitionAlpha;
    [SerializeField] SpriteRenderer transitionImage;
    private Color32 transitionColor;
    private string transitionScene;
    private int transitionSceneInt;

    void Start()
    {
        transitionColor = Color.white;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Coffee Shop":
                switch (MainManager.Instance.transitionStop)
                {
                    case true:
                        transitionColor.a = 0;
                        transitionImage.color = transitionColor;
                        break;

                    case false:
                        MainManager.Instance.transitionStop = true;
                        StartCoroutine(transition1());
                        break;
                }
                break;

            default:
                //MainManager.Instance.transitionStop = false;
                StartCoroutine(transition1());
                break;
        }
    }

    IEnumerator transition1()
    {
        transitionAlpha = 255;

        while (true)
        {
            if (transitionAlpha == 0)
            {
                break;
            }

            transitionAlpha -= 5;
            transitionColor.a = transitionAlpha;
            transitionImage.color = transitionColor;

            yield return new WaitForSeconds(1 / 60f);
        }
    }

    public void transition2a(string Scene)
    {
        transitionScene = Scene;
        StartCoroutine(transition2b());
    }

    public void transition2a(int Scene)
    {
        transitionSceneInt = Scene;
        StartCoroutine(transition2c());
    }

    IEnumerator transition2b()
    {
        while (true)
        {
            if (transitionAlpha == 255)
            {
                break;
            }

            transitionAlpha += 5;
            transitionColor.a = transitionAlpha;
            transitionImage.color = transitionColor;

            yield return new WaitForSeconds(1 / 60f);
        }

        yield return new WaitForSeconds(0.4f);

        if (transitionScene == "Dialogue")
        {
            MainManager.Instance.GetComponent<AudioSource>().enabled = false;
            MainManager.Instance.GetComponent<AudioSource>().time = 0;
        }

        else if (transitionScene == "Coffee Shop")
        {
            MainManager.Instance.GetComponent<AudioSource>().enabled = true;
        }

        SceneManager.LoadScene(transitionScene);
    }

    IEnumerator transition2c()
    {
        while (true)
        {
            if (transitionAlpha == 255)
            {
                break;
            }

            transitionAlpha += 5;
            transitionColor.a = transitionAlpha;
            transitionImage.color = transitionColor;

            yield return new WaitForSeconds(1 / 60f);
        }

        yield return new WaitForSeconds(0.4f);



        SceneManager.LoadScene(transitionSceneInt);
    }
}
