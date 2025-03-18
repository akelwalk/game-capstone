using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginRhythm : MonoBehaviour
{
    [SerializeField] managerArrow managerArrow;

    private void OnMouseUpAsButton()
    {
        managerArrow.Begin(int.Parse(gameObject.name.Substring(0, 1)));
        transform.parent.gameObject.SetActive(false);
    }
}
