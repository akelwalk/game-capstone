using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static managerMain;

public class gamemodeMain : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
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
                managerCore.managerSelect.gamemodeChange(0);
                break;

            case 1:
                managerCore.managerSelect.gamemodeChange(1);
                break;

            case 4:
                switch (managerCore.managerSelect.getMode())
                {
                    case 0:
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 1);
                        break;

                    case 1:
                        MainManager.Instance.setLevel(managerCore.managerSelect.getSelect() - 1);
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 1);
                        break;        

                    case 2:
                        MainManager.Instance.setLevel(managerCore.managerSelect.getSelect() - 1);
                        transitionObject.GetComponent<transitionSmooth>().transitionStart(true, 3);
                        break;
                }

                break;
        }
    }
}
