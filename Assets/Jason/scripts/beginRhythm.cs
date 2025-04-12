using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginRhythm : MonoBehaviour
{
    [SerializeField] managerArrow managerArrow;

    private void OnMouseUpAsButton()
    {
        managerArrow.arrowsBegin(int.Parse(gameObject.name.Substring(0, 1)));
        transform.parent.gameObject.SetActive(false);
    }

    public void startRhythm(int rhythmTrack)
    {
        managerArrow.arrowsBegin(rhythmTrack);
        transform.parent.gameObject.SetActive(false);
    }
}
