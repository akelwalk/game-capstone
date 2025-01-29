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
 
public class DialogueTrigger : MonoBehaviour
{
    public string JSON_filepath = "";
    public Dialogue dialogue;

    public void Start(){

        //add lines from json to dialogue 
        Add_JSON_lines();
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Add_JSON_lines() {
        string filePath = Path.Combine(Application.dataPath, JSON_filepath);
        Debug.Log(filePath);
        string jsonString = File.ReadAllText(filePath);

        Dialogue loadedDialogue = JsonUtility.FromJson<Dialogue>(jsonString); // Convert JSON into Dialogue object - puts in all the dialogue/name text

        //find a way to have a list of ghost icons - ghost names - ghost encounters
        //change it so that the same dialogue SFX is applied to each person talking 

        // foreach (var line in loadedDialogue.dialogueLines) // Assign icons and audio clips
        // {
        //     if (!string.IsNullOrEmpty(line.character.name))
        //     {
        //         line.character.icon = null; //load in a sprite with the same name as the character
        //     }

        //     // if (line.dialogueSFX != null && line.dialogueSFX.Length > 0)
        //     // {
        //     //     for (int i = 0; i < line.dialogueSFX.Length; i++)
        //     //     {
        //     //         line.dialogueSFX[i] = Resources.Load<AudioClip>(line.dialogueSFX[i].name); //load in charactername1, charactername2, etc audio clips
        //     //     }
        //     // }
        // }

        // Assign loaded dialogue to the class instance
        dialogue = loadedDialogue;
    }
}