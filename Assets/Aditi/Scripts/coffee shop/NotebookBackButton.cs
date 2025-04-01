using System.Collections;
using UnityEngine;

public class NotebookBackButton : MonoBehaviour
{
    public GameObject previousMenu;
    public GameObject nextMenu;

    public DrinkMenu drinkMenu;

    public int index = 0;

    public void OnClick() {
        if (previousMenu.name != nextMenu.name){
            StartCoroutine(SwitchMenus());
        }
        
    }

    private IEnumerator SwitchMenus() {
        yield return new WaitForEndOfFrame(); 
        if (drinkMenu != null) {
            drinkMenu.updateIndex(index);
        }
        nextMenu.SetActive(true);
        // button.SetActive(true);
        previousMenu.SetActive(false);
    }

}
