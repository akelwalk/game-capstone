using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    private AudioSource audioSource;  // Reference to the AudioSource
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea; 
    private Queue<DialogueLine> lines;
    public float typingSpeed = 0.1f;
    private bool isDialogueActive = true;
    private bool clicked = false;
    private bool inTypeSentence = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
 
        lines = new Queue<DialogueLine>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Update(){
        
        if (Input.GetMouseButtonDown(0)) {
            if (inTypeSentence) {
                clicked = true; //text is currently being displayed on screen, want to fast foward text
            }
            else {
                clicked = false; 
                if (lines.Count != 0) {
                    DisplayNextDialogueLine(); //if all the dialogue is on the screen, we can move to the next dialogue line 
                }
                else {
                    //add end of dialogue behavior (disappear after this click?)
                }
                
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
  
        lines.Clear();
 
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine); //adding dialogue lines to queue
        }
 
        DisplayNextDialogueLine();
    }
 
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
 
        DialogueLine currentLine = lines.Dequeue();
        
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
 
        StopAllCoroutines();
 
        StartCoroutine(TypeSentence(currentLine));
    }
 
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        clicked = false;
        inTypeSentence = true;
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            if (clicked) {
                dialogueArea.text = dialogueLine.line;
                inTypeSentence = false;
                PlaySFX(dialogueLine.dialogueSFX);
                break;
            }
            dialogueArea.text += letter;
            PlaySFX(dialogueLine.dialogueSFX);
            yield return new WaitForSeconds(typingSpeed);
        }
        inTypeSentence = false;

    }

    private void PlaySFX(AudioClip[] dialogueSFX) {
        if (dialogueSFX.Length > 0) 
        {
            int randomIndex = Random.Range(0, dialogueSFX.Length); // Get a random index
            audioSource.PlayOneShot(dialogueSFX[randomIndex]); // Play the clip
        }
    }
 
    private void EndDialogue()
    {
        isDialogueActive = false;
    }
}