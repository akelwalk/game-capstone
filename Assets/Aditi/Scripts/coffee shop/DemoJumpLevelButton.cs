using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoJumpLevelButton : MonoBehaviour
{
    public void jump(int level) {
        MainManager.Instance.setLevel(level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
