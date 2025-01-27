using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowMain;
    [SerializeField] bool arrowGenerateEnabled;
    [SerializeField] int arrowGenerateSpeed;

    private IEnumerator arrowCoroutine;
    private Vector3 arrowRotate1;
    private Vector3 arrowRotate3;
    private Vector3 arrowRotate2;
    private Vector3 arrowPosition1;
    private Vector3 arrowPosition2;
    private Vector3 arrowPosition3;
    private bool arrowGenerateActive;

    void Start()
    {
        arrowRotate1 = new Vector3 (0, 0, -90);
        arrowRotate3 = new Vector3 (0, 0, 180);
        arrowRotate2 = new Vector3 (0, 0, 90);
        arrowPosition1 = new Vector3 (-6.8f, -5.5f, 0);
        arrowPosition2 = new Vector3 (-4.85f, -5.5f, 0);
        arrowPosition3 = new Vector3 (-2.9f, -5.5f, 0);

        if (arrowGenerateEnabled == true)
        {
            arrowCoroutine = arrows1();
        }
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
            movementArrow movementArrow = gameObject.transform.GetChild(1).GetComponent<movementArrow>();

            if (Input.GetKeyDown(movementArrow.arrowLetter) == true)
            {
                switch (gameObject.transform.GetChild(1).transform.localPosition.y)
                {
                    case >= 4.45f and <= 4.55f:
                        movementArrow.arrows2();
                        Debug.Log("Great!");
                        break;

                    case >= 4.35f and <= 4.65f:
                        movementArrow.arrows2();
                        Debug.Log("Good");
                        break;

                    case >= 4.1f and <= 4.9f:
                        movementArrow.arrows2();
                        Debug.Log("Okay");
                        break;

                    case >= 3.5f:
                        movementArrow.arrows2();
                        Debug.Log("Miss");
                        break;
                }

                gameObject.transform.SetAsLastSibling();
            }
        }
    }

    IEnumerator arrows1()
    {
        while (true)
        {
            GameObject arrowClone = Instantiate(arrowMain, gameObject.transform, false);
            arrows2(arrowClone);
            arrowClone.SetActive(true);

            yield return new WaitForSeconds(1f / arrowGenerateSpeed);
        }
    }

    void arrows2(GameObject arrowClone)
    {
        switch (Random.Range(0, 4))
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
}