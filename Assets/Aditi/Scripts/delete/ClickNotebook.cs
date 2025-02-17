using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class ClickNotebook : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject mainMenu;
    public GameObject nextMenu;
    public GameObject button;

    private void Awake() {

    }
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("down");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("up");
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("click");
        StartCoroutine(SwitchMenus());
    }

    private IEnumerator SwitchMenus() {
        yield return new WaitForEndOfFrame(); 
        nextMenu.SetActive(true);
        // button.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("enter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("exit");
    }


}
