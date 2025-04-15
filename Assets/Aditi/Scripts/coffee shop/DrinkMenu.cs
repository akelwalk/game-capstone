using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
    public class Drink
    {
        public string name;
        public string recipe;
        public string description;
    }

    [System.Serializable]
    public class DrinkData
    {
        public List<Drink> drinks;
    }

public class DrinkMenu : MonoBehaviour
{
    public TextAsset jsonDrinks;
    private DrinkData drinkData;
    public TMP_Text drinkNameText;
    public TMP_Text recipeText;
    public TMP_Text descriptionText;
    
    public Image imageBox;
    // public GameObject oldMenu;
    // public GameObject drinkMenu;
    public List<Sprite> drinkSprites;
    [HideInInspector] public int index = 0;

    public void Awake()
    {
        drinkData = JsonUtility.FromJson<DrinkData>(jsonDrinks.text);
    }

    // public void getDrink(int index) {
    //     // switchMenus();
    //     drinkNameText.text = drinkData.drinks[index].name;
    //     recipeText.text = drinkData.drinks[index].recipe;
    //     descriptionText.text = drinkData.drinks[index].description;

    //     imageBox.sprite = drinkSprites[0];
    //     //resizing necessary a little
    //     // drinkData.drinks[index]
    // }

    // public void switchMenus() {
    //     oldMenu.SetActive(false);
    //     drinkMenu.SetActive(true);
    // } 

    public void updateIndex(int i) {
        index = i;
        updateText();
    }

    public void updateText()
    {
        drinkNameText.text = drinkData.drinks[index].name;
        recipeText.text = drinkData.drinks[index].recipe;
        descriptionText.text = drinkData.drinks[index].description;
        imageBox.sprite = drinkSprites[index];
    }



}
