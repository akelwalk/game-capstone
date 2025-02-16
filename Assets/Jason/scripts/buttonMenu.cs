using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static managerMain;

public class buttonMenu : MonoBehaviour
{
    int buttonNumber;

    void Start()
    {
        buttonNumber = int.Parse(gameObject.name.Substring(0, 1));
    }

    void OnMouseUpAsButton()
    {
        managerCore.managerMenu.buttons1();
    }

    void OnMouseOver()
    {
        managerCore.managerMenu.buttons2(buttonNumber);
    }

    void OnMouseExit()
    {
        managerCore.managerMenu.buttons3(buttonNumber);
    }

    void OnMouseDown()
    {
        managerCore.managerMenu.buttons4(buttonNumber);
    }

    void OnMouseUp()
    {
        managerCore.managerMenu.buttons5();
    }
}
