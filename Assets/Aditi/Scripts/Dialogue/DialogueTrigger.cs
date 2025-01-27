using System.Collections.Generic;
using UnityEngine;
 
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
    public AudioClip[] dialogueSFX;
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
    public Dialogue dialogue;

    public void Start(){
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}