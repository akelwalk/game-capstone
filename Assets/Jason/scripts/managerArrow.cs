using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class managerArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowMain;
    [SerializeField] GameObject characterMain;
    [SerializeField] bool arrowGenerateEnabled;
    [SerializeField] int arrowGeneratePerSecond;
    [SerializeField] AudioSource stageMusic;

    private IEnumerator arrowCoroutine;
    private IEnumerator characterCoroutine;
    private Vector3 characterRotate0;
    private Vector3 characterRotate1;
    private Vector3 characterRotate2;
    private Vector3 characterRotate3;
    private Vector3 arrowRotate1;
    private Vector3 arrowRotate3;
    private Vector3 arrowRotate2;
    private Vector3 arrowPosition1;
    private Vector3 arrowPosition2;
    private Vector3 arrowPosition3;
    private bool arrowGenerateActive;
    private int characterQuality;
    private string[] stageTimings;
    private int arrowCount;

    void Start()
    {
        characterRotate0 = new Vector3(0, 0, 40);
        characterRotate1 = new Vector3(0, 0, 20);
        characterRotate2 = new Vector3(0, 0, -10);
        characterRotate3 = new Vector3(0, 0, -30);
        arrowRotate1 = new Vector3 (0, 0, -90);
        arrowRotate3 = new Vector3 (0, 0, 180);
        arrowRotate2 = new Vector3 (0, 0, 90);
        arrowPosition1 = new Vector3 (-6.8f, -5.5f, 0);
        arrowPosition2 = new Vector3 (-4.85f, -5.5f, 0);
        arrowPosition3 = new Vector3 (-2.9f, -5.5f, 0);

        if (arrowGenerateEnabled == true)
        {
            arrowCoroutine = arrows1();
            characterCoroutine = character1();
        }

        /* stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2A.txt");

        for (int x = 0; x < stageTimings.Length; x++)
        {
            stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
        }

        File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2B.txt", stageTimings); */
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (arrowGenerateEnabled, arrowGenerateActive)
            {
                case (true, true):
                    arrowGenerateActive = !arrowGenerateActive;
                    StopCoroutine(arrowCoroutine);
                    break;

                case (true, false):
                    arrowGenerateActive = !arrowGenerateActive;
                    StartCoroutine(arrowCoroutine);
                    Invoke("music1", 0);
                    break;

                default:
                    GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);
                    arrows2(arrowClone);
                    arrowClone.SetActive(true);
                    break;
            }

        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            arrowGenerateEnabled = !arrowGenerateEnabled;
            StopCoroutine(arrowCoroutine);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            movementArrow movementArrow = gameObject.transform.GetChild(5).GetComponent<movementArrow>();

            if (Input.GetKeyDown(movementArrow.arrowLetter) == true)
            {
                switch (gameObject.transform.GetChild(5).transform.localPosition.y)
                {
                    case >= 4.45f and <= 4.55f:
                        movementArrow.arrows2(0);
                        characterQuality = 0;
                        break;

                    case >= 4.35f and <= 4.65f:
                        movementArrow.arrows2(1);
                        characterQuality = 1;
                        break;

                    case >= 4.1f and <= 4.9f:
                        movementArrow.arrows2(2);
                        characterQuality = 2;
                        break;

                    case >= 3.5f:
                        movementArrow.arrows2(3);
                        characterQuality = 3;
                        break;
                }

                StartCoroutine(characterCoroutine);
                gameObject.transform.SetAsLastSibling();
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            StartCoroutine(MoveRandomly());
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            arrowMain.GetComponent<movementArrow>().arrows3();
        }
    }

    IEnumerator arrows1()
    {
        stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2B.txt");

        while (true)
        {
            GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);
            arrows2(arrowClone);
            arrowClone.transform.position = new Vector3(arrowClone.transform.position.x, arrowClone.transform.position.y, arrowCount * 0.0001f);
            arrowClone.SetActive(true);

            // yield return new WaitForSeconds(1f / arrowGeneratePerSecond);

            if (arrowCount == stageTimings.Length)
            {
                Debug.Log(stageTimings[arrowCount]);
                break;
            }

            else
            {
                yield return new WaitForSeconds((float.Parse(stageTimings[arrowCount + 1]) - float.Parse(stageTimings[arrowCount])) * (50.4f/42));
                arrowCount++;
            }
        }
    }

    void arrows2(GameObject arrowClone)
    {
        switch (/* Random.Range(0, 4) */ 1)
        {
            case 0:
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.A;
                break;

            case 1:
                arrowClone.transform.eulerAngles = arrowRotate1;
                arrowClone.transform.localPosition = arrowPosition1;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.W;
                break;

            case 2:
                arrowClone.transform.eulerAngles = arrowRotate2;
                arrowClone.transform.localPosition = arrowPosition2;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.S;
                break;

            case 3:
                arrowClone.transform.eulerAngles = arrowRotate3;
                arrowClone.transform.localPosition = arrowPosition3;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.D;
                break;
        }
    }

    IEnumerator character1()
    {
        while (true)
        {
            switch (characterQuality)
            {
                case 0:
                    characterMain.transform.eulerAngles = characterRotate0;
                    break;

                case 1:
                    characterMain.transform.eulerAngles = characterRotate1;
                    break;

                case 2:
                    characterMain.transform.eulerAngles = characterRotate2;
                    break;

                case 3:
                    characterMain.transform.eulerAngles = characterRotate3;
                    break;
            }

            yield return new WaitForSeconds(1 / 2f);
            characterMain.transform.eulerAngles = Vector3.zero;
            StopCoroutine(characterCoroutine);
        }
    }

    void music1()
    {
        stageMusic.time = 4.25f;
        stageMusic.enabled = true;
    }




    public Transform targetPoint; // The point around which the object moves

    private IEnumerator MoveRandomly()
    {
        targetPoint = transform.parent.transform;

        while (true)
        {
            Vector3 randomPoint = GetRandomPointAroundTarget();
            yield return StartCoroutine(MoveToPosition(randomPoint));
            yield return null;
        }
    }

    private Vector3 GetRandomPointAroundTarget()
    {
        float angle = Random.Range(0f, 360f);
        float x = Random.Range(0, 10);
        float y = Random.Range(0, -3.5f);
        return targetPoint.position + new Vector3(x, y, 0);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 0.6f;
            float smoothStep = Mathf.SmoothStep(0f, 1f, elapsedTime);
            transform.position = Vector3.Lerp(startingPosition, targetPosition, smoothStep);

            yield return null;
        }

        transform.position = targetPosition;
    }
}