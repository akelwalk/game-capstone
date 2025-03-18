using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.UI;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;

public class SpawnIngredient : MonoBehaviour
{
    public Canvas canvas;
    public GameObject ingredient;

    public void spawn() {
        // Instantiate the ingredient prefab
        GameObject newObject = Instantiate(ingredient);

        // Set the parent to be the canvas, ensuring it's under the canvas with proper scaling
        newObject.transform.SetParent(canvas.transform, false); // 'false' keeps local scale intact

        // Get the DragIngredient component
        DragIngredient dragIngredient = newObject.GetComponent<DragIngredient>();
        if (dragIngredient != null) {
            dragIngredient.canvas = canvas;
        }

        // Make sure the new object uses the correct RectTransform settings
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        if (rectTransform != null) {
            rectTransform.localScale = Vector3.one; // Ensure scale is set correctly
            rectTransform.anchoredPosition = Vector2.zero; // Or set a specific position if needed
        }
    }
}