using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemoEndMessage : MonoBehaviour
{
    public GameObject game;
    public GameObject end;
    public TMP_Text message;

    public void Start()
    {
        end.SetActive(false);
    }

    public void EndGame() {
        end.SetActive(true);
        if (MainManager.Instance.success) {
            message.text = "Success! The ghost liked your drink.";
        }
        else {
            message.text = "Fail. You've disappointed your customer.";
        }
        game.SetActive(false);
    }
}
