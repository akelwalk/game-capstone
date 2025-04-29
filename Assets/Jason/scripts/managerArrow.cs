using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class managerArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowMain;
    [SerializeField] GameObject characterMain;
    [SerializeField] GameObject rhythmEnd;

    [SerializeField] TextMeshProUGUI arrowScoreDisplay;

    [SerializeField] AudioClip[] stageTracks;
    [SerializeField] AudioSource stageMusic;

    [SerializeField] bool arrowGenerateEnabled;
    [SerializeField] int arrowGeneratePerSecond;

    private IEnumerator arrowCoroutine0;
    private IEnumerator moveCoroutine1;
    private IEnumerator moveCoroutine2;


    private Vector3 arrowRotate1;
    private Vector3 arrowRotate3;
    private Vector3 arrowRotate2;
    private Vector3 arrowPosition1;
    private Vector3 arrowPosition2;
    private Vector3 arrowPosition3;

    private float instantiateOffset;
    private float instantiateScale;
    private float musicStart;

    private int arrowCount;
    private int arrowScore;

    [SerializeField] Sprite[] danceBG;
    [SerializeField] GameObject backgroundObj;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] GameObject audioMain;

    private List<List<float>> timingsAll;
    private int arrowTimings0;
    private int arrowTimings1;
    private int arrowTimings2;
    private int arrowTimings3;
    private int arrowDifficulty;
    private int trackPlaying;
    private int arrowWiggle;

    private bool rhythmFinished;
    private bool moveStart;

    void Start()
    {
        musicStart = -1;
        timingsAll = new List<List<float>>();
        arrowRotate1 = new Vector3 (0, 0, -90);
        arrowRotate3 = new Vector3 (0, 0, 180);
        arrowRotate2 = new Vector3 (0, 0, 90);
        arrowPosition1 = new Vector3 (-6.8f, -5.5f, 0);
        arrowPosition2 = new Vector3 (-4.85f, -5.5f, 0);
        arrowPosition3 = new Vector3 (-2.9f, -5.5f, 0);
        moveCoroutine1 = MoveRandomly();
        moveCoroutine2 = MoveReturn();

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

        /* stageTimings = File.ReadAllLines(Application.dataPath + "/Jason/csv/stage2A.txt");

        for (int x = 0; x < stageTimings.Length; x++)
        {
            stageTimings[x] = stageTimings[x].Substring(0, stageTimings[x].IndexOf(','));
        }

        File.WriteAllLines(Application.dataPath + "/Jason/csv/stage2B.txt", stageTimings); */
    }

    void Update()
    {
        switch (trackPlaying)
        {
            case 1:
                if (Time.unscaledTime - musicStart >= 32 && moveStart == false && musicStart != -1)
                {
                    StartCoroutine(moveCoroutine1);
                    moveStart = true;
                }

                else if (Time.unscaledTime - musicStart >= 76 && moveStart == true)
                {
                    StopCoroutine(moveCoroutine1);
                    StartCoroutine(moveCoroutine2);
                    musicStart = -1;
                    moveStart = false;
                }
                break;

            case 2:
                if (Time.unscaledTime - musicStart >= 26 && arrowWiggle == 0 && musicStart != -1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 1;
                }

                else if (Time.unscaledTime - musicStart >= 58 && arrowWiggle == 1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 2;
                }

                if (Time.unscaledTime - musicStart >= 39 && moveStart == false && musicStart != -1)
                {
                    StartCoroutine(moveCoroutine1);
                    moveStart = true;
                }

                else if (Time.unscaledTime - musicStart >= 61 && moveStart == true)
                {
                    StopCoroutine(moveCoroutine1);
                    StartCoroutine(moveCoroutine2);
                    musicStart = -1;
                    moveStart = false;
                }
                break;

            case 3:
                if (Time.unscaledTime - musicStart >= 23 && arrowWiggle == 0 && musicStart != -1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 1;
                }

                else if (Time.unscaledTime - musicStart >= 34 && arrowWiggle == 1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 2;
                }
                break;

            case 4:
                if (Time.unscaledTime - musicStart >= 35 && arrowWiggle == 0 && musicStart != -1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 1;
                }

                else if (Time.unscaledTime - musicStart >= 78.5f && arrowWiggle == 1)
                {
                    arrowMain.GetComponent<movementArrow>().arrows3();
                    arrowWiggle = 2;
                }

                if (Time.unscaledTime - musicStart >= 36 && moveStart == false && musicStart != -1)
                {
                    StartCoroutine(moveCoroutine1);
                    moveStart = true;
                }

                else if (Time.unscaledTime - musicStart >= 78.5f && moveStart == true)
                {
                    StopCoroutine(moveCoroutine1);
                    StartCoroutine(moveCoroutine2);
                    musicStart = -1;
                    moveStart = false;
                }
                break;
        }

        try
        {
            if (arrowTimings0 < timingsAll[0].Count && stageMusic.time - instantiateOffset >= (timingsAll[0][arrowTimings0] * instantiateScale))
            {
                arrowsMovement(0);
                arrowTimings0++;
            }

            if (arrowTimings1 < timingsAll[1].Count && stageMusic.time - instantiateOffset >= (timingsAll[1][arrowTimings1] * instantiateScale))
            {
                arrowsMovement(1);
                arrowTimings1++;
            }

            if (arrowTimings2 < timingsAll[2].Count && stageMusic.time - instantiateOffset >= (timingsAll[2][arrowTimings2] * instantiateScale))
            {
                arrowsMovement(2);
                arrowTimings2++;
            }

            if (arrowTimings3 < timingsAll[3].Count && stageMusic.time - instantiateOffset >= (timingsAll[3][arrowTimings3] * instantiateScale))
            {
                arrowsMovement(3);
                arrowTimings3++;
            }

            /* if (Input.GetKeyUp(KeyCode.Return))
            {
                arrowGenerateEnabled = !arrowGenerateEnabled;
                StopCoroutine(arrowCoroutine0);
            } */

            if (transform.childCount > 6 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                movementArrow movementArrow = gameObject.transform.GetChild(6).GetComponent<movementArrow>();

                if (Input.GetKeyDown(movementArrow.arrowLetter) == true || Input.GetKeyDown(movementArrow.arrowDirection) == true)
                {
                    Vector3 location = new Vector3((gameObject.transform.GetChild(6).transform.position.x - 0.3f) * 0.94f, (gameObject.transform.GetChild(6).transform.position.y + 0.2f) * 0.94f, 0);

                    switch (gameObject.transform.GetChild(6).transform.localPosition.y)
                    {
                        case >= 4.4f and <= 4.6f:
                            arrowScore += 1000;
                            movementArrow.arrows2(0);
                            arrowsEffects(0);
                            GameObject tempParticle = gameObject.transform.GetChild(5).transform.GetChild(0).gameObject;
                            GameObject clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 4.25f and <= 4.75f:
                            arrowScore += 400;
                            movementArrow.arrows2(1);
                            arrowsEffects(1);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(1).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 3.9f and <= 5.1f:
                            arrowScore += 100;
                            movementArrow.arrows2(2);
                            arrowsEffects(2);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(2).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 3:
                            movementArrow.arrows2(3);
                            arrowsEffects(2);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(3).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;
                    }

                    arrowScoreDisplay.text = "Score: " + arrowScore;
                    gameObject.transform.SetAsLastSibling();
                }

                else
                {

                    Vector3 location = new Vector3((gameObject.transform.GetChild(6).transform.position.x - 0.3f) * 0.94f, (gameObject.transform.GetChild(6).transform.position.y + 0.2f) * 0.94f, 0);

                    switch (gameObject.transform.GetChild(6).transform.localPosition.y)
                    {
                        case >= 3:
                            movementArrow.arrows2(3);
                            arrowsEffects(2);
                            GameObject tempParticle = gameObject.transform.GetChild(5).transform.GetChild(3).gameObject;
                            GameObject clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;
                    }
                }
            }

            else if (transform.childCount > 6 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                movementArrow movementArrow = gameObject.transform.GetChild(6).GetComponent<movementArrow>();

                if (Input.GetKeyDown(movementArrow.arrowLetter) == true || Input.GetKeyDown(movementArrow.arrowDirection) == true)
                {
                    Vector3 location = new Vector3((gameObject.transform.GetChild(6).transform.position.x - 0.3f) * 0.94f, (gameObject.transform.GetChild(6).transform.position.y + 0.2f) * 0.94f, 0);

                    switch (gameObject.transform.GetChild(6).transform.localPosition.y)
                    {
                        case >= 4.4f and <= 4.6f:
                            arrowScore += 1000;
                            movementArrow.arrows2(0);
                            arrowsEffects(0);
                            GameObject tempParticle = gameObject.transform.GetChild(5).transform.GetChild(0).gameObject;
                            GameObject clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 4.25f and <= 4.75f:
                            arrowScore += 400;
                            movementArrow.arrows2(1);
                            arrowsEffects(1);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(1).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 3.9f and <= 5.1f:
                            arrowScore += 100;
                            movementArrow.arrows2(2);
                            arrowsEffects(2);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(2).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;

                        case >= 3:
                            movementArrow.arrows2(3);
                            arrowsEffects(2);
                            tempParticle = gameObject.transform.GetChild(5).transform.GetChild(3).gameObject;
                            clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;
                    }

                    arrowScoreDisplay.text = "Score: " + arrowScore;
                    gameObject.transform.SetAsLastSibling();
                }

                else
                {

                    Vector3 location = new Vector3((gameObject.transform.GetChild(6).transform.position.x - 0.3f) * 0.94f, (gameObject.transform.GetChild(6).transform.position.y + 0.2f) * 0.94f, 0);

                    switch (gameObject.transform.GetChild(6).transform.localPosition.y)
                    {
                        case >= 3:
                            movementArrow.arrows2(3);
                            arrowsEffects(2);
                            GameObject tempParticle = gameObject.transform.GetChild(5).transform.GetChild(3).gameObject;
                            GameObject clone = Instantiate(tempParticle, location, movementArrow.gameObject.transform.localRotation);
                            clone.SetActive(true);
                            break;
                    }
                }
            }

            if (rhythmFinished == false && arrowTimings0 >= timingsAll[0].Count && arrowTimings1 >= timingsAll[1].Count && arrowTimings2 >= timingsAll[2].Count && arrowTimings3 >= timingsAll[3].Count)
            {
                rhythmFinished = true;
                musicStart = -1;
                Invoke("endRhythm", 5);
            }
        }
        catch { }
    }

    private void endRhythm()
    {
        arrowWiggle = 0;
        rhythmEnd.SetActive(true);
        MainManager.Instance.increaseLevel();
    }

    public void arrowsBegin(int trackNumber)
    {
        trackPlaying = trackNumber;

        for (int x = 0; x < 4; x++)
        {
            string[] arrowLines = new string[0];
            List<float> timingsFile = new List<float>();
            arrowDifficulty = PlayerPrefs.GetInt("arrowDifficulty");
            string difficultyName = "EASY";

            switch (arrowDifficulty)
            {
                case 1:
                    difficultyName = "MEDIUM";
                    break;

                case 2:
                    difficultyName = "HARD";
                    break;
            }

            switch (x)
            {
                case 0:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csvNew/stage" + trackNumber + "A_" + difficultyName + ".txt");
                    break;

                case 1:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csvNew/stage" + trackNumber + "B_" + difficultyName + ".txt");
                    break;

                case 2:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csvNew/stage" + trackNumber + "C_" + difficultyName + ".txt");
                    break;

                default:
                    arrowLines = File.ReadAllLines(Application.streamingAssetsPath + "/csvNew/stage" + trackNumber + "D_" + difficultyName + ".txt");
                    break;

            }


            for (int y = 0; y < arrowLines.Length; y++)
            {
                timingsFile.Add(float.Parse(arrowLines[y]));
            }

            timingsAll.Add(timingsFile);
        }

        instantiateScale = 1;
        switch (trackNumber)
        {
            case 1:
                instantiateOffset = -1.25f;
                break;

            case 2:
                instantiateOffset = -1.25f;
                instantiateScale = 1.2f;
                break;

            case 3:
                instantiateOffset = -1.1f;
                instantiateScale = 0.75f;
                break;


            case 4:
                instantiateOffset = -1.2f;
                instantiateScale = 0.9f;
                break;
        }

        stageMusic.clip = stageTracks[trackNumber - 1];
        stageMusic.volume = 0.5f * (PlayerPrefs.GetInt("audioMusic") / 20f);
        backgroundObj.GetComponent<SpriteRenderer>().sprite = danceBG[trackNumber - 1];
        Invoke("musicMain", 0);
    }

    private void arrowsMovement(int arrowDirection)
    {
        GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);

        switch (arrowDirection)
        {
            case 0:
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.A;
                arrowClone.GetComponent<movementArrow>().arrowDirection = KeyCode.LeftArrow;
                break;

            case 1:
                arrowClone.transform.eulerAngles = arrowRotate1;
                arrowClone.transform.localPosition = arrowPosition1;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.W;
                arrowClone.GetComponent<movementArrow>().arrowDirection = KeyCode.UpArrow;
                break;

            case 2:
                arrowClone.transform.eulerAngles = arrowRotate2;
                arrowClone.transform.localPosition = arrowPosition2;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.S;
                arrowClone.GetComponent<movementArrow>().arrowDirection = KeyCode.DownArrow;
                break;

            case 3:
                arrowClone.transform.eulerAngles = arrowRotate3;
                arrowClone.transform.localPosition = arrowPosition3;
                arrowClone.GetComponent<movementArrow>().arrowLetter = KeyCode.D;
                arrowClone.GetComponent<movementArrow>().arrowDirection = KeyCode.RightArrow;
                break;
        }

        arrowClone.transform.position = new Vector3(arrowClone.transform.position.x, arrowClone.transform.position.y, arrowCount * 0.0001f);
        arrowClone.SetActive(true);
    }

    private void arrowsEffects(int audioClip)
    {
        audioSource.clip = audioClips[audioClip];
        audioSource.volume = PlayerPrefs.GetInt("audioSounds") / 20f;
        GameObject audioClone = Instantiate(audioMain, audioMain.transform.parent);
        audioClone.SetActive(true);
    }

    public void musicMain()
    {
        stageMusic.enabled = true;
        musicStart = Time.unscaledTime;
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


    /* IEnumerator arrows1(string arrowFile, int arrowDirection)
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
            }
        }
    } */

    /* void arrows2(GameObject arrowClone, int arrowDirection)
    {

    } */

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






    */
}