using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Create Item")]

public class Item : ScriptableObject
{
    [SerializeField] private string itemName;

    [SerializeField] private bool isObjective;

    // scene to find this item
    [SerializeField] private string sceneToFind;

    [SerializeField] private ItemType itemType; 

    public enum ItemType {
        Key,
        Potion,
        MeleeWeapon,
        GunWeapon,
        Ammo
    }

    public string ItemName {
        get {return itemName;}
        set { itemName = value;}
    }

    public bool IsObjective {
        get {return isObjective;}
        set {isObjective = value;}
    }

    public string SceneToFind {
        get {return sceneToFind;}
        set {sceneToFind = value;}
    }

    public ItemType Type {
        get { return itemType; }
        set { itemType = value; }
    }

    public virtual void Use() {
        Debug.Log("Use Item");
    }
}
