using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rhythmEnd : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
 
    private void OnMouseUpAsButton()
    {
        switch (MainManager.Instance.getLevel())
        {
            case >= 10:
                transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 0);
                break;

            default:
                transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 1);
                break;
        }
    }
}
