using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerMain : MonoBehaviour
{
    public static managerMain managerCore;
    public managerMenu managerMenu;
    public managerSelect managerSelect;

    void Start()
    {
        managerCore = this;
    }
}
