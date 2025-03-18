using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class NotebookBackButton : MonoBehaviour
{
    public GameObject previousMenu;
    public GameObject nextMenu;

    public void OnClick() {
        if (previousMenu.name != nextMenu.name){
            StartCoroutine(SwitchMenus());
        }
        
    }

    private IEnumerator SwitchMenus() {
        yield return new WaitForEndOfFrame(); 
        nextMenu.SetActive(true);
        // button.SetActive(true);
        previousMenu.SetActive(false);
    }

}
