using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookBackButton : MonoBehaviour
{
    public GameObject previousMenu;
    public GameObject nextMenu;

    public void OnClick() {
        StartCoroutine(SwitchMenus());
    }

    private IEnumerator SwitchMenus() {
        yield return new WaitForEndOfFrame(); 
        nextMenu.SetActive(true);
        // button.SetActive(true);
        previousMenu.SetActive(false);
    }

}
