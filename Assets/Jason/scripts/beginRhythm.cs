using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginRhythm : MonoBehaviour
{
    [SerializeField] managerArrow managerArrow;
    private int rhythmTrackMain;

    private void OnMouseUpAsButton()
    {
        managerArrow.arrowsBegin(int.Parse(gameObject.name.Substring(0, 1)));
        transform.parent.gameObject.SetActive(false);
    }

    public void startRhythm(int rhythmTrack)
    {
        rhythmTrackMain = rhythmTrack;

        Invoke("trueStart", 0.05f);
    }

    private void trueStart()
    {
        managerArrow.arrowsBegin(rhythmTrackMain);
        transform.parent.gameObject.SetActive(false);
    }

}
