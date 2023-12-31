using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string _message;
    public string message
    {
        get { return _message; }
        set {_message = value;}
    }

    public bool isObjective { get; set; }

    public bool hasBeenClicked { get; set; }

    public KeyScriptableObject key;

    public void Interact()
    {
        Debug.Log("Add key " + key.KeyName + " to player inventory. Message: " + _message);
        InventoryManager.Instance.AddItemToList(key);
        //remove the key from the game object
        
        // display pop up dialogue
        DialogueManager.Instance.playObjectMessage(message);
    }

}
