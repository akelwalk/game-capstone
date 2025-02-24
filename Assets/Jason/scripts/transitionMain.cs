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
                transitionColor.a = 0;
                transitionImage.color = transitionColor;
                MainManager.Instance.transitionStop = false;
                break;

            default:
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
