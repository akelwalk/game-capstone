using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
   public void restartScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
