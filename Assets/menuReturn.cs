using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuReturn : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 0);
            MainManager.Instance.stopMusic();
        }
    }
}
