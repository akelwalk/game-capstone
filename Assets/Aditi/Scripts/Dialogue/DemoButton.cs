using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoButton : MonoBehaviour
{
    public int maxLevel = 20;
    private DialogueTrigger trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public void nextInteraction() {
        Debug.Log(MainManager.Instance.getLevel());
        if (MainManager.Instance.getLevel() < maxLevel-1) {
            MainManager.Instance.increaseLevel();
            trigger.Start();
        }
    }
}
