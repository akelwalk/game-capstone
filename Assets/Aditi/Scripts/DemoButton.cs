using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoButton : MonoBehaviour
{
    private DialogueTrigger trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public void nextInteraction() {
        MainManager.Instance.increaseLevel();
        trigger.Start();
    }
}
