using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int level;
    public Customer customer;
    public List<string> drinks;
}

[System.Serializable]
public class Customer
{
    public string name;
    public string description;
}

[System.Serializable]
public class GameData
{
    public List<LevelData> levels;
}

public class Cauldron : MonoBehaviour
{

    public Dictionary<string, List<string>> recipes = new Dictionary<string, List<string>>();
    public TextAsset jsonOrders; 
    private string order; //do we still need this?
    private List<string> recipe = new List<string>();
    private List<string> currentIngredients = new List<string>();
    private GameData gameData;
    private AudioSource audioSource;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        // Add drink names and their corresponding ingredients
        //phase 1
        recipes.Add("Twilight Velvet", new List<string> { "Ghost Brew", "Whisper Syrup" });
        recipes.Add("Celestial Cocoa", new List<string> { "Cocoa", "Stardust Sugar" });
        recipes.Add("Ember Awakening", new List<string> { "Infernal Roast", "Honeydew" });
        recipes.Add("Moonlit Comfort", new List<string> { "Moonlit Tea", "Whisper Syrup" });
        recipes.Add("Midnight Frost", new List<string> { "Nocturnal Drip", "Cloud Foam" });
        recipes.Add("Dreamcatcher", new List<string> { "Ghost Brew", "Stardust Sugar" });
        recipes.Add("Eclipsed Mocha", new List<string> { "Cocoa", "Whisper Syrup" });
        recipes.Add("Sunfire Espresso", new List<string> { "Infernal Roast", "Stardust Sugar" });
        recipes.Add("Lunar Bloom", new List<string> { "Moonlit Tea", "Cloud Foam" });
        recipes.Add("Starry Drip", new List<string> { "Nocturnal Drip", "Stardust Sugar" });

        //phase 2
        recipes.Add("Ember's Hollow", new List<string> { "Abyssal Espresso", "Maple", "Hollow Crystals" });
        recipes.Add("Obsidian Reign", new List<string> { "Abyssal Espresso", "Shadow Water", "Soulshards", "Nightshade" });
        recipes.Add("Abyssal Bloom", new List<string> { "Abyssal Espresso", "Soul Milk", "Maple", "Hollow Crystals" });
        recipes.Add("Crimson Haze", new List<string> { "Shadow Water", "Maple", "Hollow Crystals" });
        recipes.Add("Dawn's Lament", new List<string> { "Veilbrew", "Soul Milk", "Obsidian Vanilla", "Glow Pearls" });
        recipes.Add("Radiance", new List<string> { "Soul Milk", "Obsidian Vanilla", "Glow Pearls" });
        recipes.Add("The Shifting", new List<string> { "Veilbrew", "Soulshards", "Glow Pearls" });
        recipes.Add("Mistbound", new List<string> { "Veilbrew", "Soul Milk", "Obsidian Vanilla", "Glow Pearls" });
        recipes.Add("Faded Silence", new List<string> { "Shadow Water", "Veilbrew", "Soulshards", "Nightshade" });
        recipes.Add("EclipseVeil", new List<string> { "Veilbrew", "Obsidian Vanilla", "Glow Pearls" });

    }

    void Start()
    {
        // if (order != null) {
        //     ingredients = recipes[order];
        // }
        // else if (order == "") {
        //     //no order, figure out drink yourself
        // }

        if (jsonOrders != null)
        {
            gameData = JsonUtility.FromJson<GameData>(jsonOrders.text);
            order = gameData.levels[MainManager.Instance.getLevel()].drinks[0];
            Debug.Log("Drink to make: " + order);
            if (order != "") {
                recipe = recipes[order]; 
            }
        }
    }

    public void checkRecipe() {
        MainManager.Instance.success = true;
        if (recipe.Count != currentIngredients.Count) { //the number of ingredients in the cauldron should match the number of ingredients the recipe calls for 
            MainManager.Instance.success = false; 
        }
        else {
            for (int i = 0; i < recipe.Count; i++) { //the only ingredients in the cauldron should be the ones in the recipe
                if (!currentIngredients.Contains(recipe[i] + "(Clone)")) {
                    MainManager.Instance.success = false;
                }
            }
        }
        Debug.Log("success status: " + MainManager.Instance.success);
    }

    // public void printIngredients(List<string> list)
    // {
    //     for (int i = 0; i < list.Count; i++) {
    //         Debug.Log(list[i] + "\n");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ingredient")) {
            Debug.Log("Added " + other.gameObject.name);
            audioSource.Play();
            currentIngredients.Add(other.gameObject.name); //adding the name of ingredient to the cauldron
            other.gameObject.SetActive(false);

            //testing something, remove later
            // DragIngredients ingredient = other.gameObject.GetComponent<DragIngredients>();
            // ingredient.canDrag = false;
            // StartCoroutine(HandleIngredientReset(other));
        }
        else {
            Debug.Log("did you set the ingredient label?");
        }
    }


    // private IEnumerator HandleIngredientReset(Collider2D other)
    // {
    //     DragIngredients ingredient = other.gameObject.GetComponent<DragIngredients>();
    //     ingredient.resetLocation();
    //     yield return null;

    // }
}
