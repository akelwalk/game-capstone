using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class DemoEndMessage : MonoBehaviour
{
    public GameObject game;
    public GameObject end;
    public TMP_Text message;
    public Image imageBox;
    public Sprite happy;
    public Sprite sad;
    public TextAsset jsonMessages; 
    private EndData endData;
    public float typingSpeed = 0.5f;
    private bool clicked = false;
    private bool inTypeSentence = false;
    private AudioSource audioSource;

    [Serializable]
    public class EndDialogue
    {
        public int level;
        public List<DialogueLine> success;
        public List<DialogueLine> failure;
    }

    [Serializable]
    public class EndData
    {
        public List<EndDialogue> levels;
    }

    public void Awake()
    {
        endData = JsonUtility.FromJson<EndData>(jsonMessages.text);
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        end.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (inTypeSentence) {
                clicked = true; //text is currently being displayed on screen, want to fast foward text
            }
        }
    }

    public void EndGame() {
        end.SetActive(true);
        if (MainManager.Instance.success) {
            // message.text = "Success! The ghost liked your drink.";
            // message.text = endData.levels[MainManager.Instance.getLevel()].success[0].line;
            StartCoroutine(TypeSentence(endData.levels[MainManager.Instance.getLevel()].success[0]));
            imageBox.sprite = happy;
        }
        else {
            // message.text = "Fail. You've disappointed your customer.";
            // message.text = endData.levels[MainManager.Instance.getLevel()].failure[0].line;
            if (!inTypeSentence) {
                StartCoroutine(TypeSentence(endData.levels[MainManager.Instance.getLevel()].failure[0]));
            }
            
            imageBox.sprite = sad;
        }
        game.SetActive(false);
    }


    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        clicked = false;
        inTypeSentence = true;
        message.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            if (clicked) {
                message.text = dialogueLine.line;
                inTypeSentence = false;
                audioSource.Play();
                break;
            }
            message.text += letter;
            audioSource.Play();
            if (letter == ' ') {
                continue;
            }
            else if (letter == '.' || letter == '?' || letter == '?' || letter == '!') {
                yield return new WaitForSeconds(typingSpeed * 2.4f);
            }
            else if (letter == ',') {
                yield return new WaitForSeconds(typingSpeed * 1.5f);
            }
            else {
                yield return new WaitForSeconds(typingSpeed);
            }
            
        }
        inTypeSentence = false;

    }
}
