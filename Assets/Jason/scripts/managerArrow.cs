using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class managerArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowMain;
    [SerializeField] GameObject characterMain;
    [SerializeField] bool arrowGenerateEnabled;
    [SerializeField] int arrowGeneratePerSecond;
    [SerializeField] AudioSource stageMusic;
    [SerializeField] TextMeshProUGUI arrowScoreDisplay;

    private IEnumerator arrowCoroutine0;
    private IEnumerator arrowCoroutine1;
    private IEnumerator arrowCoroutine2;
    private IEnumerator arrowCoroutine3;
    private IEnumerator moveCoroutine1;
    private IEnumerator moveCoroutine2;
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
    private bool coroutineActive;
    private int arrowScore;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] GameObject audioMain;


    private List<List<float>> timingsAll;
    private int arrowTimings0;
    private int arrowTimings1;
    private int arrowTimings2;
    private int arrowTimings3;

    void Start()
    {
        timingsAll = new List<List<float>>();

        for (int x = 0; x < 4; x++)
        {
            string[] arrowLines = new string[0];
            List<float> timingsFile = new List<float>();

            switch (x)
            {
                case 0:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csv/stage1A.txt");
                    break;

                case 1:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csv/stage1B.txt");
                    break;

                case 2:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csv/stage1C.txt");
                    break;

                default:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csv/stage1D.txt");
                    break;

            }


            for (int y = 0; y < arrowLines.Length; y++)
            {
                timingsFile.Add(float.Parse(arrowLines[y]));
            }

            timingsAll.Add(timingsFile);
        }

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
        // moveCoroutine1 = MoveRandomly();
        // moveCoroutine2 = MoveReturn();

        /* if (arrowGenerateEnabled == true)
        {
            arrowCoroutine0 = arrows1("/csv/stage1A.txt", 0);
            arrowCoroutine1 = arrows1("/csv/stage1B.txt", 1);
            arrowCoroutine2 = arrows1("/csv/stage1C.txt", 2);
            arrowCoroutine3 = arrows1("/csv/stage1D.txt", 3);
            characterCoroutine = character1();
        } */
        
        //StartCoroutine(arrowCoroutine0);
        //StartCoroutine(arrowCoroutine1);
        //StartCoroutine(arrowCoroutine2);
        //StartCoroutine(arrowCoroutine3);
        Invoke("music1", 0);

        /* stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2A.txt");

        for (int x = 0; x < stageTimings.Length; x++)
        {
            stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
        }

        File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2B.txt", stageTimings); */
    }

    void Update()
    {
        if (arrowTimings0 < timingsAll[0].Count && stageMusic.time - 4.75f >= timingsAll[0][arrowTimings0])
        {
            arrowInstantiate(0);
            arrowTimings0++;
        }

        if (arrowTimings1 < timingsAll[1].Count && stageMusic.time - 4.75f >= timingsAll[1][arrowTimings1])
        {
            arrowInstantiate(1);
            arrowTimings1++;
        }

        if (arrowTimings2 < timingsAll[2].Count && stageMusic.time - 4.75f >= timingsAll[2][arrowTimings2])
        {
            arrowInstantiate(2);
            arrowTimings2++;
        }

        if (arrowTimings3 < timingsAll[3].Count && stageMusic.time - 4.75f >= timingsAll[3][arrowTimings3])
        {
            arrowInstantiate(3);
            arrowTimings3++;
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            arrowGenerateEnabled = !arrowGenerateEnabled;
            StopCoroutine(arrowCoroutine0);
        }

        if (transform.childCount > 5 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            movementArrow movementArrow = gameObject.transform.GetChild(5).GetComponent<movementArrow>();

            if (Input.GetKeyDown(movementArrow.arrowLetter) == true)
            {
                switch (gameObject.transform.GetChild(5).transform.localPosition.y)
                {
                    case >= 4.4f and <= 4.6f:
                        arrowScore += 1000;
                        movementArrow.arrows2(0);
                        arrowSounds(0);
                        characterQuality = 0;
                        break;

                    case >= 4.25f and <= 4.75f:
                        arrowScore += 400;
                        movementArrow.arrows2(1);
                        arrowSounds(1);
                        characterQuality = 1;
                        break;

                    case >= 3.9f and <= 5.1f:
                        arrowScore += 100;
                        movementArrow.arrows2(2);
                        arrowSounds(2);
                        characterQuality = 2;
                        break;

                    case >= 3.5f:
                        movementArrow.arrows2(3);
                        arrowSounds(2);
                        characterQuality = 3;
                        break;
                }

                arrowScoreDisplay.text = "Score: " + arrowScore;
                //StartCoroutine(characterCoroutine);
                gameObject.transform.SetAsLastSibling();
            }
        }
    }

    private void arrowInstantiate(int arrowDirection)
    {
        GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);

        switch (arrowDirection)
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

        arrowClone.transform.position = new Vector3(arrowClone.transform.position.x, arrowClone.transform.position.y, arrowCount * 0.0001f);
        arrowClone.SetActive(true);
    }

    void music1()
    {
        stageMusic.enabled = true;
    }

    private void arrowSounds(int audioClip)
    {
        audioSource.clip = audioClips[audioClip];
        GameObject audioClone = Instantiate(audioMain, audioMain.transform.parent);
        audioClone.SetActive(true);
    }

    IEnumerator arrows1(string arrowFile, int arrowDirection)
    {
        yield return new WaitForSeconds(4.22f);

        //stageTimings = File.ReadAllLines(Application.streamingAssetsPath + arrowFile);

        while (arrowCount < stageTimings.Length - 1)
        {
            GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);
            arrows2(arrowClone, arrowDirection);
            arrowClone.transform.position = new Vector3(arrowClone.transform.position.x, arrowClone.transform.position.y, arrowCount * 0.0001f);
            arrowClone.SetActive(true);

            /* switch (arrowCount)
            {
                case 12:
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    break;

                case 48:
                    if (coroutineActive == false)
                    {
                        coroutineActive = true;
                        StartCoroutine(moveCoroutine1);
                    }
                    break;

                case 65:
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    break;

                case 87:
                    StopCoroutine(moveCoroutine1);
                    StartCoroutine(moveCoroutine2);
                    break;
            }

            if (arrowCount == stageTimings.Length)
            {
                Debug.Log(stageTimings[arrowCount]);
                break;
            }

            else
            {
                yield return new WaitForSeconds((float.Parse(stageTimings[arrowCount + 1]) - float.Parse(stageTimings[arrowCount])) * (50.4f / 42));
                arrowCount++;
            } */
        }
    }


    void arrows2(GameObject arrowClone, int arrowDirection)
    {

    }

    /*

    IEnumerator arrows1(string arrowFile, int arrowDirection)
    {
        yield return new WaitForSeconds(4.22f);

        stageTimings = File.ReadAllLines(Application.streamingAssetsPath + arrowFile);

        while (arrowCount < stageTimings.Length - 1)
        {
            Debug.Log(AudioSettings.dspTime);
            GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);
            arrows2(arrowClone, arrowDirection);
            arrowClone.transform.position = new Vector3(arrowClone.transform.position.x, arrowClone.transform.position.y, arrowCount * 0.0001f);
            arrowClone.SetActive(true);

            switch (arrowCount)
            {
                case 12:
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    break;

                case 48:
                    if (coroutineActive == false)
                    {
                        coroutineActive = true;
                        StartCoroutine(moveCoroutine1);
                    }
                    break;

                case 65:
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    break;

                case 87:
                    StopCoroutine(moveCoroutine1);
                    StartCoroutine(moveCoroutine2);
                    break;
            }

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
        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime * 0.6f;
            float smoothStep = Mathf.SmoothStep(0f, 1f, elapsedTime);
            transform.position = Vector3.Lerp(startingPosition, targetPosition, smoothStep);

            yield return null;
        }

        transform.position = targetPosition;
    }

    private IEnumerator MoveReturn()
    {
        yield return new WaitForSeconds(.4f);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * 0.03f;
            float smoothStep = Mathf.SmoothStep(0f, 1f, elapsedTime);
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, smoothStep);

            yield return null;

            if (transform.position.x < 0.0001f)
            {
                transform.position = Vector3.zero;
                StopCoroutine(MoveReturn());
            }
        }
    }

    */
}