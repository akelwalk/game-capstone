using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public class ingredientSystem
    {
        public Ingredient type;
        public List<Sprite> ingredientList;
        public List<GameObject> prefabList;
    }
    public List<ingredientSystem> selections1 = new List<ingredientSystem>();
    public List<ingredientSystem> selections2 = new List<ingredientSystem>();
    public List<ingredientSystem> selection3 = new List<ingredientSystem>();
    
    public TMP_Text selectionText;

    private int index = 0;
    private List<ingredientSystem> selections;

    public void Start()
    {
        if (MainManager.Instance.getLevel() < 10) {
            selections = selections1;
        }
        else if (MainManager.Instance.getLevel() < 20) {
            selections = selections2;
        }
        else if (MainManager.Instance.getLevel() < 30) {
            selections = selection3;
        }
        // selections = selections2; //TESTING PURPOSES
        switchSelection(selections[0].ingredientList);
        updateText(selections[0].type);
    }

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
