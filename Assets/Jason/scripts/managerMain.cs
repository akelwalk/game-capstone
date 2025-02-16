using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerMain : MonoBehaviour
{
    public static managerMain managerCore;
    public managerMenu managerMenu;

    void Start()
    {
        managerCore = this;
    }
}
