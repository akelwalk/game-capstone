using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Shelf : MonoBehaviour
{

    //dont change ever enums are scary
    public enum Ingredient
    {
        Base,
        Sweetener,
        Topping,
    }

    public List<Image> imageBoxes; //need 4
    public List<SpawnIngredient> buttons;

    [System.Serializable]
    public class serializableClass
    {
        public Ingredient type;
        public List<Sprite> ingredientList;
        public List<GameObject> prefabList;
    }
    public List<serializableClass> selections = new List<serializableClass>();
    
    public TMP_Text selectionText;

    int index = 0;

    public void updateText(Ingredient type) {
        // string formatted = char.ToUpper(text[0]) + text.Substring(1);
        if (type == Ingredient.Base) {
            selectionText.text = "Base";
        }
        else if (type == Ingredient.Sweetener) {
            selectionText.text = "Sweetener";
        }
        else {
            selectionText.text = "Topping";
        }
        
    }

    public void forwardSelection() {
        index++;
        if (index == selections.Count) {
            index = 0;
        }

        switchSelection(selections[index].ingredientList);
        updateText(selections[index].type);
    }

    public void backwardsSelection() {
        index --;
        if (index < 0) {
            index = selections.Count -1;
        }

        switchSelection(selections[index].ingredientList);
        updateText(selections[index].type);
    }

    public void switchSelection(List<Sprite> sprites) {
        foreach (Image i in imageBoxes)
        {
            i.gameObject.SetActive(false);
        }

        int n = sprites.Count;

        for (int i = 0; i < n; i++) {
            imageBoxes[i].gameObject.SetActive(true);
            imageBoxes[i].sprite = sprites[i];
            buttons[i].ingredient = selections[index].prefabList[i];
        }
    }
}
