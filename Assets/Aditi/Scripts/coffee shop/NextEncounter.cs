using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEncounter : MonoBehaviour
{
    [SerializeField] transitionMain transitionMain;

    public void Next() {
        MainManager.Instance.increaseLevel();
        SceneManager.LoadScene("Dialogue");
        // transitionMain.transition2a("Dialogue");
    }
}
