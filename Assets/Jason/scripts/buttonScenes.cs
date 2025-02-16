using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScenes : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
