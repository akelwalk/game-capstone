using UnityEngine;
using System.Collections;


public class SpawnIngredient : MonoBehaviour
{
    public Canvas canvas;
    public GameObject ingredient;

    public void spawn() {
        GameObject newObject = Instantiate(ingredient);
        newObject.transform.SetParent(gameObject.transform.parent.transform, false);

        DragIngredient draggable = newObject.GetComponent<DragIngredient>();
        if (draggable != null)
        {
            draggable.StartDragging();
        }

        // // Get the DragIngredient component
        // DragIngredient dragIngredient = newObject.GetComponent<DragIngredient>();
        // if (dragIngredient != null) {
        //     dragIngredient.canvas = canvas;
        // }

        // Make sure the new object uses the correct RectTransform settings
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        if (rectTransform != null) {
            rectTransform.localScale = Vector3.one; // Ensure scale is set correctly
            rectTransform.anchoredPosition = Vector2.zero; // Or set a specific position if needed
        }

        
    }

    // private IEnumerator spawnSomething()
    // {
    //     GameObject newObject = Instantiate(ingredient);
    //     newObject.transform.SetParent(transform.parent, false);
    //     yield break;
    // }




}