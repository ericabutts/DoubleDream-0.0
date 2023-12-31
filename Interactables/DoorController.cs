using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] public string doorMessage;

    [SerializeField] public string keyName;

    public string message
    {
        get { return doorMessage; }
        set { doorMessage = value; }
    }

    public bool hasBeenClicked { get; set; } = false;

    public string name { get; set; }

    [SerializeField] public bool _isObjective;

    [SerializeField] public bool _isLocked;

    public bool isLocked {
        get {return _isLocked;} 
        set {isLocked = _isLocked;}
    }

    public bool isObjective {
        get {return _isObjective;}
        set {isObjective = _isObjective;}
    }

    public string KeyName {
        get {return keyName;}
        set {keyName = value;}
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log("Door touched "+other);
        if(other.CompareTag("Player")) {
            // Debug.Log("check the inventory for a key called " +keyName);
            foreach (Item item in InventoryManager.Instance.itemsList) {
                if (item.ItemName == keyName) {
                    Debug.Log("DOOR OPENED");
                    this.gameObject.SetActive(false);
                }
            }
        }
    }


    public void Interact() {
        if (isLocked) {
            DialogueManager.Instance.playObjectMessage("The door is locked...");
        } else {
            DialogueManager.Instance.playObjectMessage(message);
            if (isObjective) {
                QuestManager.currentQuest.removeQuestEntryFromCurrentQuestArray(this.gameObject.name);
            }
        }
    }



}
