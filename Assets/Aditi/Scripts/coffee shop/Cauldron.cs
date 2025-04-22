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
    // private string order;
    public Dictionary<string, List<string>> acceptableDrinks = new Dictionary<string, List<string>>();
    // private List<string> recipe = new List<string>();
    private List<string> currentIngredients = new List<string>();
    private GameData gameData;
    private AudioSource audioSource;
    public AudioClip[] cauldronSFX;
    
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
        
        //phase 3
        recipes.Add("Underleaf", new List<string> { "Matcha", "Truffle", "Silvermist", "Dreamwhip" });
        recipes.Add("Fogwalker", new List<string> { "Matcha", "Silvermist", "Gloamdew", "Glow Ice" });
        recipes.Add("Forest Bloom", new List<string> { "Spirit Soda", "Matcha", "Crimsonberry", "Gloamdew" });
        recipes.Add("Berry Fizz", new List<string> { "Spirit Soda", "Moonflower", "Starberries", "Glow Ice" });
        recipes.Add("Ashroot", new List<string> { "Chai", "Crimsonberry", "Starberries", "Glow Ice" });
        recipes.Add("Earthbound", new List<string> { "Chai", "Truffle", "Silvermist", "Dreamwhip" });
        recipes.Add("Mirewood", new List<string> { "Dreadshot", "Truffle", "Silvermist", "Dreamwhip" });
        recipes.Add("Reflection's End", new List<string> { "Dreadshot", "Truffle", "Starberries", "Gloamdew" });
        recipes.Add("Mistlock", new List<string> { "Spirit Soda", "Silvermist", "Gloamdew", "Dreamwhip" });
        recipes.Add("Nightshock", new List<string> { "Dreadshot", "Moonflower", "Truffle", "Glow Ice" });


    }

    void Start()
    {
        //so we have the acceptable orders dictionary we add that order to the dictionary
        if (jsonOrders != null)
        {
            gameData = JsonUtility.FromJson<GameData>(jsonOrders.text);
            
            // order = gameData.levels[MainManager.Instance.getLevel()].drinks[0];
            // Debug.Log("Drink to make: " + order);
            // if (order != "") {
            //     recipe = recipes[order]; 
            // }

            List<string> drinkList = gameData.levels[MainManager.Instance.getLevel()].drinks;
            foreach (string drink in drinkList) {
                acceptableDrinks.Add(drink, recipes[drink]);
            }

        }
    }

    public void checkRecipe() {
        // MainManager.Instance.success = true;
        // if (recipe.Count != currentIngredients.Count) { //the number of ingredients in the cauldron should match the number of ingredients the recipe calls for 
        //     MainManager.Instance.success = false; 
        // }
        // else {
        //     for (int i = 0; i < recipe.Count; i++) { //the only ingredients in the cauldron should be the ones in the recipe
        //         if (!currentIngredients.Contains(recipe[i] + "(Clone)")) {
        //             MainManager.Instance.success = false;
        //         }
        //     }
        // }
        // Debug.Log("success status: " + MainManager.Instance.success);

        MainManager.Instance.success = false;
        foreach (KeyValuePair<string, List<string>> entry in acceptableDrinks)
        {
            string drink = entry.Key;
            List<string> recipeh = entry.Value;

            bool contains = true;
            for (int i = 0; i < recipeh.Count; i++) { 
                if (!currentIngredients.Contains(recipeh[i] + "(Clone)")) {
                    contains = false;
                }
            }

            if (contains && recipeh.Count == currentIngredients.Count) { //the only ingredients in the cauldron should be the ones in the recipe
                MainManager.Instance.success = true;
                break;
            }
        }   
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
            PlaySFX();
            currentIngredients.Add(other.gameObject.name); //adding the name of ingredient to the cauldron
            other.gameObject.SetActive(false);
        }
        else {
            Debug.Log("did you set the ingredient label?");
        }
    }

    private void PlaySFX() {
        if (cauldronSFX.Length > 0) 
        {
            int randomIndex = Random.Range(0, cauldronSFX.Length); // Get a random index
            audioSource.PlayOneShot(cauldronSFX[randomIndex]); // Play the clip
        }
    }

}
