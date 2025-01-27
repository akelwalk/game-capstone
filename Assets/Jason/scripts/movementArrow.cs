using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementArrow : MonoBehaviour
{
    public KeyCode arrowLetter;

    [SerializeField] Vector3 arrowMovement;

    private SpriteRenderer arrowSprite;
    private IEnumerator arrowCoroutine;
    private Color32 arrowColor;
    private Vector3 arrowScale;
    private bool arrowDisappear;
    private byte arrowAlpha;

    private void Start()
    {
        arrowSprite = gameObject.GetComponent<SpriteRenderer>();
        arrowCoroutine = arrows1();
        arrowColor = Color.white;
        arrowAlpha = 255;
    }

    void FixedUpdate()
    {
        gameObject.transform.localPosition += arrowMovement / 40f;
        gameObject.transform.localScale += arrowScale;

        if (gameObject.transform.localPosition.y >= 4.55 && arrowDisappear == false)
        {
            arrowDisappear = true;
            StartCoroutine(arrowCoroutine);
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

            yield return new WaitForSeconds(1 / 60f);
        }
    }

    public void arrows2()
    {
        arrowMovement = Vector3.zero;
        arrowScale = Vector3.one / 20f;
        StartCoroutine(arrowCoroutine);
    }
}
