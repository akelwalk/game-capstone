using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionSmooth : MonoBehaviour
{
    private Transform leftImage;
    private Transform rightImage;
    private int slideSpeed = 8;
    private float imageMax = 12;
    private float imageMin = 0;

    private IEnumerator transitionCoroutine;
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    public bool transitionDirection;
    public bool transitionOnce;
    private static bool transitionOccured;
    private BoxCollider2D transtionBlock;

    /* private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    } */

    void Start()
    {
        leftImage = transform.GetChild(0).transform;
        rightImage = transform.GetChild(1).transform;

        leftPosition = leftImage.localPosition;
        rightPosition = rightImage.localPosition;

        transtionBlock = gameObject.GetComponent<BoxCollider2D>();

        if (transitionDirection == true || transitionOccured == true)
        {
            Debug.Log(transitionDirection + " | " + transitionOccured);
            gameObject.transform.GetChild(1).localPosition = new Vector2(imageMax, 0.5246475f);
            gameObject.transform.GetChild(0).localPosition = new Vector2(-imageMax, 0.5246475f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        else if (transitionOccured == false)
        {
            if (transitionOnce == true)
            {
                transitionOccured = true;
            }

            transitionStart(false, -1);
        }
    }

    public void transitionStart(bool transitionDirection, int sceneChange)
    {
        transitionCoroutine = transitionMain(transitionDirection, sceneChange);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        StartCoroutine(transitionCoroutine);
    }

    public void transitionStart(bool transitionDirection, string sceneChange)
    {
        transitionCoroutine = transitionMain(transitionDirection, sceneChange);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        StartCoroutine(transitionCoroutine);
    }

    private IEnumerator transitionMain(bool transitionDirection, int sceneChange)
    {
        while (true)
        {
            Vector3 leftMovement = leftPosition;
            Vector3 rightMovement = rightPosition;

            switch (transitionDirection)
            {
                case true:
                    leftMovement.x = leftMovement.x - imageMin;
                    rightMovement.x = rightMovement.x + imageMin;
                    break;

                case false:
                    leftMovement.x = leftMovement.x - imageMax;
                    rightMovement.x = rightMovement.x + imageMax;
                    break;
            }

            leftImage.localPosition = Vector3.Lerp(leftImage.localPosition, leftMovement, Time.deltaTime * slideSpeed);
            rightImage.localPosition = Vector3.Lerp(rightImage.localPosition, rightMovement, Time.deltaTime * slideSpeed);

            if (Vector3.Distance(leftImage.localPosition, leftMovement) < 0.01f && Vector3.Distance(rightImage.localPosition, rightMovement) < 0.01f)
            {

                leftImage.localPosition = leftMovement;
                rightImage.localPosition = rightMovement;
                transitionDirection = !transitionDirection;
                transtionBlock.enabled = false;

                if (sceneChange >= 0)
                {
                    transitionOccured = false;
                    Debug.Log(transitionOccured);
                    SceneManager.LoadScene(sceneChange);
                }

                StopCoroutine(transitionCoroutine);
            }

            yield return null;
        }
    }

    private IEnumerator transitionMain(bool transitionDirection, string sceneChange)
    {
        while (true)
        {
            Vector3 leftMovement = leftPosition;
            Vector3 rightMovement = rightPosition;

            switch (transitionDirection)
            {
                case true:
                    leftMovement.x = leftMovement.x - imageMin;
                    rightMovement.x = rightMovement.x + imageMin;
                    break;

                case false:
                    leftMovement.x = leftMovement.x - imageMax;
                    rightMovement.x = rightMovement.x + imageMax;
                    break;
            }

            leftImage.localPosition = Vector3.Lerp(leftImage.localPosition, leftMovement, Time.deltaTime * slideSpeed);
            rightImage.localPosition = Vector3.Lerp(rightImage.localPosition, rightMovement, Time.deltaTime * slideSpeed);

            if (Vector3.Distance(leftImage.localPosition, leftMovement) < 0.01f && Vector3.Distance(rightImage.localPosition, rightMovement) < 0.01f)
            {

                leftImage.localPosition = leftMovement;
                rightImage.localPosition = rightMovement;
                transitionDirection = !transitionDirection;
                transtionBlock.enabled = false;

                transitionOccured = false;
                Debug.Log(transitionOccured);
                SceneManager.LoadScene(sceneChange);

                StopCoroutine(transitionCoroutine);
            }

            yield return null;
        }
    }
}