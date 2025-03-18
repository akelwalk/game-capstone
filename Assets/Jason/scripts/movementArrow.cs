using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movementArrow : MonoBehaviour
{
    public KeyCode arrowLetter;
    public KeyCode arrowDirection;

    [SerializeField] Vector3 arrowMovement0;
    [SerializeField] Vector3 arrowMovement1;
    [SerializeField] Vector3 arrowMovement2;

    private SpriteRenderer arrowSprite;
    private IEnumerator arrowCoroutine;
    private Color32 arrowColor;
    private Vector3 arrowScale;
    private bool arrowDisappear;
    private byte arrowAlpha;
    private float startTime;
    public bool arrowWiggle;
    private bool arrowMiss;


    private void Start()
    {
        arrowSprite = gameObject.GetComponent<SpriteRenderer>();
        arrowCoroutine = arrows1();
        arrowColor = Color.white;
        arrowAlpha = 255;
        startTime = Time.time;

        switch((int) Random.Range(0, 2))
        {
            case 0:
                startTime = Time.time;
                break;

            case 1:
                startTime = Time.time + 1;
                break;
        }
    }

    void FixedUpdate()
    {
        switch (arrowWiggle, startTime % 2)
        {
            case (true, < 1):
                gameObject.transform.localPosition += arrowMovement1 / 40f;
                startTime += Time.deltaTime * 3;
                break;

            case (true, > 1):
                gameObject.transform.localPosition += arrowMovement2 / 40f;
                startTime += Time.deltaTime * 3;
                break;

            default:
                gameObject.transform.localPosition += arrowMovement0 / 40f;
                break;
        }

        gameObject.transform.localScale += arrowScale;

        if (arrowMiss == false)
        {
            if (gameObject.transform.localPosition.y >= 4.55 && arrowDisappear == false)
            {
                arrowDisappear = true;
                StartCoroutine(arrowCoroutine);
            }

            else if (gameObject.transform.localPosition.y > 5.1 && arrowSprite.color.ToHexString().Substring(0, 2) == "FF")
            {
                arrows2(3);
            }
        }
    }

    IEnumerator arrows1()
    {
        while (true)
        {
            if (arrowAlpha == 0)
            {
                Destroy(gameObject);
            }

            arrowAlpha -= 15;
            arrowColor.a = arrowAlpha;
            arrowSprite.color = arrowColor;

            yield return new WaitForFixedUpdate();
        }
    }

    public void arrows2(int arrowQuality)
    {
        arrowMovement0 = Vector3.zero;
        arrowMovement1 = Vector3.zero;
        arrowMovement2 = Vector3.zero;
        arrowScale = Vector3.one / 20f;
        StartCoroutine(arrowCoroutine);

        if (gameObject.transform.localPosition.y < 4.55)
        {
            StartCoroutine(arrowCoroutine);
        }

        switch (arrowQuality)
        {
            case 0:
                arrowColor = Color.cyan;
                break;

            case 1:
                arrowColor = Color.green;
                break;

            case 2:
                arrowColor = Color.yellow;
                break;

            case 3:
                arrowColor = Color.red;
                break;
        }
    }

    public void arrows3()
    {
        arrowWiggle = !arrowWiggle;
    }
}
