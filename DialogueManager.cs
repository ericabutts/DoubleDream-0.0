using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI characterNameTextA;
    public TextMeshProUGUI characterNameTextB;
    public TextAsset csvFile;
    public GameObject dialogueDisplayObject;
    public int currentRowCounter;
    List<string> dialogue = new List<string>();
    List<string> audioQueue = new List<string>();
    List<string> characterDisplay = new List<string>();
    public bool dialogueActive;
    

    public Image characterImageUILeft;

    public AudioSource audioSource;


    public void increaseDialogueCounter() {
        if (currentRowCounter < dialogue.Count-1) {
            currentRowCounter += 1;
            dialogueText.text = dialogue[currentRowCounter];
            
        } else {
            dialogue.Clear();
            closeDialogueBox();
        }
    }

    public void showSpeakingCharacter() {
        characterImageUILeft.sprite = Resources.Load<Sprite>(characterDisplay[currentRowCounter]);  
        characterNameTextA.text = characterDisplay[currentRowCounter];
    }

    public void handleDialogueButtonClick() {
        increaseDialogueCounter();
        // showSpeakingCharacter();
        handleAudioClip();
        
    }

    public void handleAudioClip() {
        audioSource = GetComponent<AudioSource>();
        // AudioClip clip = (AudioClip) Resources.Load("promiscuous");
        // audioSource.PlayOneShot(clip);
    }

    void Update() {
        if (dialogueActive) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                // Debug.Log("You clicked the spacebar,.");
                increaseDialogueCounter();
            }
        }
    }

    public void startDialogue() {
        //set new csv, then call start dialogue
        TextAsset csv = csvFile;
        currentRowCounter = 1;
        dialogueActive = true;
        if (dialogueActive) {
            openDialogueBox();
        } 

        parseCsv(csv);
        // showSpeakingCharacter();
        dialogueText.text = dialogue[currentRowCounter];
    }

    void Start()
    {
        if (Instance) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        dialogueDisplayObject = GameObject.Find("DialogueDisplay");
        
        //make sure dialogue display is active
        //startDialogue(csvFile);
    }

    public void openDialogueBox() {
        Debug.Log("open dialogue box");
        //dialogueDisplayObject.SetActive(true);
        dialogueDisplayObject.GetComponent<CanvasGroup>().alpha = 1;
        dialogueDisplayObject.GetComponent<CanvasGroup>().interactable = true;
        dialogueDisplayObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        dialogueActive = true;

    }

    public void closeDialogueBox() {
        //dialogueDisplayObject.SetActive(false);
        dialogueDisplayObject.GetComponent<CanvasGroup>().alpha = 0;
        dialogueDisplayObject.GetComponent<CanvasGroup>().interactable = false;
        dialogueDisplayObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        dialogueActive = false;
    }

    public void playObjectMessage(string message) {
        openDialogueBox();
        dialogueText.text = message;
    }


    private List<string> parseCsv(TextAsset csv) {
        string[] data = csv.text.Split('\n');
        foreach (string row in data) {
            // Debug.Log(row);
            string[] elements = row.Split(',');
            dialogue.Add(elements[0]);
            audioQueue.Add(elements[1]);
            characterDisplay.Add(elements[2]);
        
        }
        return dialogue;
    }

}
