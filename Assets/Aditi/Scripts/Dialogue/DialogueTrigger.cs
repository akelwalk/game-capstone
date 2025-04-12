using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon; //might not be a sprite
}
 
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}
 
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

[System.Serializable]
public class DialogueData
{
    public List<LevelDialogue> levels;
}

[System.Serializable]
public class LevelDialogue
{
    public int level;
    public List<DialogueLine> dialogueLines;
}

public class DialogueTrigger : MonoBehaviour
{
    // public string JSON_filepath = "";
    public TextAsset jsonDialogue;
    public Sprite strawberrySprite;
    public List<Sprite> ghostSprites;
    public Dialogue dialogue;

    public void Start(){
        //add lines from json to dialogue 
        Add_JSON_lines();
        Invoke("startDelay", 0);
    
    }

    private void startDelay()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Add_JSON_lines() {
        DialogueData data = JsonUtility.FromJson<DialogueData>(jsonDialogue.text); // Convert JSON into Dialogue object - puts in all the dialogue/name text
        int index = MainManager.Instance.getLevel(); //get index of the current level
        dialogue.dialogueLines = data.levels[index].dialogueLines; //get current level's dialogue lines

        foreach (var line in dialogue.dialogueLines) // Assign icons
        {
            if (line.character.name == "Rehema") {
                line.character.icon = strawberrySprite;
            }
            // else if (line.character.name == "Grim Reaper") {
            //     //TODO
            // }
            else {
                line.character.icon = ghostSprites[Random.Range(0, ghostSprites.Count)]; //choose a random ghost sprite for anyone that's not strawberry
            }
        }
    }
}