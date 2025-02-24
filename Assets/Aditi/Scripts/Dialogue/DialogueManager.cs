using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO; 
using UnityEngine.SceneManagement;
 
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    private AudioSource audioSource;  // Reference to the AudioSource
    public AudioClip[] dialogueSFX;
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea; 
    private Queue<DialogueLine> lines;
    public float typingSpeed = 0.1f;
    private bool isDialogueActive = true;
    private bool clicked = false;
    private bool inTypeSentence = false;
    [SerializeField] transitionMain transitionMain;

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
                    if (MainManager.Instance.getLevel() == 2)
                    { //third level
                        transitionMain.transition2a(4);
                    }
                    else {
                        transitionMain.transition2a("Coffee Shop");
                    }
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
        
        if (currentLine.character.icon != null) {
            characterIcon.sprite = currentLine.character.icon;
        }
        
        if (currentLine.character.name != null) {
            characterName.text = currentLine.character.name;
        }
 
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
                PlaySFX(dialogueSFX);
                break;
            }
            dialogueArea.text += letter;
            PlaySFX(dialogueSFX);
            if (letter == ' ') {
                continue;
            }
            else if (letter == '.' || letter == '?' || letter == ',' || letter == '?') {
                yield return new WaitForSeconds(typingSpeed * 2.4f);
            }
            else if (letter == ',') {
                yield return new WaitForSeconds(typingSpeed * 1.2f);
            }
            else {
                yield return new WaitForSeconds(typingSpeed);
            }
            
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