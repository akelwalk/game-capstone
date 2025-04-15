using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static managerMain;

public class levelMain : MonoBehaviour
{
    private int objectNumber;
    private void Start()
    {
        objectNumber = int.Parse(gameObject.name.Substring(0, 1));
    }

    private void OnMouseUpAsButton()
    {

        switch (objectNumber)
        {
            case 0:
                managerCore.managerSelect.levelChange(0);
                break;

            case 1:
                managerCore.managerSelect.levelChange(1);
                break;
        }
    }
}
