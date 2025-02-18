using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EndData
{
    public List<Level> levels;
}

[System.Serializable]
public class Level
{
    public int level;
    public List<DialogueLine> success;
    public List<DialogueLine> fail;
}

public class EndDialogueTrigger : MonoBehaviour
{
    // public string JSON_filepath = "";
    public TextAsset jsonDialogue;
    public Sprite strawberrySprite;
    public List<Sprite> ghostSprites;
    public Dialogue dialogue;

    public void Start(){
        //add lines from json to dialogue 
        Add_JSON_lines();
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Add_JSON_lines() {
        EndData data = JsonUtility.FromJson<EndData>(jsonDialogue.text); // Convert JSON into Dialogue object - puts in all the dialogue/name text
        Debug.Log(data.levels[0].success[0].line);
        Debug.Log(data.levels[0].success[1].line);
        Debug.Log(data.levels[0].success[2].line);
        int index = MainManager.Instance.getLevel(); //get index of the current level
        // if (MainManager.Instance.success) {
        //     dialogue.dialogueLines = data.levels[index].success; //get current level's dialogue lines
        // }
        // else {
        //     dialogue.dialogueLines = data.levels[index].fail; //get current level's dialogue lines
        // }
        

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