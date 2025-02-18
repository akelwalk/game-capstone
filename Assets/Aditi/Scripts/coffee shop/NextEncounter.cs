using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEncounter : MonoBehaviour
{
    public void Next() {
        MainManager.Instance.increaseLevel();
        SceneManager.LoadScene("Dialogue");
    }
}
