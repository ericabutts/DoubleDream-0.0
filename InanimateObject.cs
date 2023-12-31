using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InanimateObject : MonoBehaviour, IInteractable
{
    public string myMessage;

    public bool hasBeenClicked {get; set; } = false;

    public string message { get; set;}

    public bool isObjective {get; set;}

    void Start() {
        // SET THE INTERACTABLE via public inspector
        gameObject.GetComponent<IInteractable>().message = myMessage;
    }

    public void Interact() {
        DialogueManager.Instance.playObjectMessage(message);
        QuestManager.currentQuest.removeQuestEntryFromCurrentQuestArray(this.gameObject.name);
    }
}
