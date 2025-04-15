using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEncounter : MonoBehaviour
{
    [SerializeField] transitionMain transitionMain;
    [SerializeField] GameObject transitionObject;

    public void Next() {
        MainManager.Instance.increaseLevel();
        MainManager.Instance.stopMusic();
        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, "Dialogue");
        // SceneManager.LoadScene("Dialogue");
        // transitionMain.transition2a("Dialogue");
    }
}
