using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItem : MonoBehaviour, IInteractable
{
    public List<Item> itemsList;

    public bool isObjective {get; set;}

    public string message {get; set;}

    public bool hasBeenClicked {get; set;}


    public void Interact() {
        Debug.Log("pick up these " + itemsList.Count +" items. Add them to " + InventoryManager.Instance.itemsList.Count + " existing items.");
        for (int i = itemsList.Count - 1; i >= 0; i--) {
            Item item = itemsList[i];
            Debug.Log("This item is a type " + item.Type);
            bool addedToInventory = InventoryManager.Instance.AddItemToList(item);
            if (addedToInventory) {
                itemsList.RemoveAt(i);
            }
        }

    }
}
