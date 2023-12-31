using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    public List<Item> itemsList;

    public int maxNumberOfPotions = 10;

    public int maxNumberOfAmmo = 5;

    public int maxNumberOfGunWeapons = 2;

    public int maxNumberOfMeleeWeapons = 1;

    public int currentNumberOfPotions = 0;

    public int currentNumberOfAmmo = 0;

    public int currentNumberOfGunWeapons = 0;

    public int currentNumberOfMeleeWeapons = 0;

    public int getCurrentInventoryQuantity(Item itemToAdd) {
        int currentPotions = 0;
        int currentAmmo = 0;
        int currentGunWeapons = 0;
        int currentMeleeWeapons = 0;

        foreach (Item item in itemsList) {
            Debug.Log(item.Type);
            if (item.Type == Item.ItemType.Potion) {
                currentPotions += 1;
            }
            if (item.Type == Item.ItemType.Ammo) {
                currentAmmo += 1;
            }
            if (item.Type == Item.ItemType.GunWeapon) {
                currentGunWeapons += 1;
            }
            if (item.Type == Item.ItemType.MeleeWeapon) {
                currentMeleeWeapons += 1;
            }
        }

        if (itemToAdd.Type == Item.ItemType.Potion) {
            return currentPotions;
        } 
        if (itemToAdd.Type == Item.ItemType.Ammo) {
            return currentAmmo;
        }
        if (itemToAdd.Type == Item.ItemType.GunWeapon) {
            return currentGunWeapons;
        }
        if (itemToAdd.Type == Item.ItemType.MeleeWeapon) {
            return currentMeleeWeapons;
        }
        
        else {
            return 0;
        }

    }

    public void setCurrentInventoryQuantity(Item item) {
        if (item.Type == Item.ItemType.Potion) {
            currentNumberOfPotions += 1;
        }
        if (item.Type == Item.ItemType.Ammo) {
            currentNumberOfAmmo += 1;
        }
        if (item.Type == Item.ItemType.GunWeapon) {
            currentNumberOfGunWeapons += 1;
        }
        if (item.Type == Item.ItemType.MeleeWeapon) {
            currentNumberOfMeleeWeapons += 1;
        }
    }

    public bool checkIfExceedsMaxQuantity(Item item, int quantity) {
        if(item.Type == Item.ItemType.Potion) {
            if (maxNumberOfPotions >= quantity + 1) {
                return false;
            } else {
                return true;
            }
        }
        if(item.Type == Item.ItemType.Ammo) {
            if (maxNumberOfAmmo >= quantity + 1) {
                // Debug.Log("return true, allow adding.");
                return false;
            } else {
                // Debug.Log("you reached the maximum");
                return true;
            }
        }
        if(item.Type == Item.ItemType.GunWeapon) {
            if (maxNumberOfGunWeapons >= quantity + 1) {
                // Debug.Log("return true, allow adding.");
                return false;
            } else {
                // Debug.Log("you reached the maximum");
                return true;
            }
        }
        if(item.Type == Item.ItemType.MeleeWeapon) {
            if (maxNumberOfMeleeWeapons >= quantity + 1) {
                // Debug.Log("return true, allow adding.");
                return false;
            } else {
                // Debug.Log("you reached the maximum");
                return true;
            }
        } else {
            Debug.Log("This is not a valid type.");
            return false;
        }
    }

    public bool AddItemToList(Item item) {
        // get the current quantity in inventory for this item type
        int quantity = getCurrentInventoryQuantity(item);
        
        //check if adding it would exceed the maximum
        bool exceedsMax = checkIfExceedsMaxQuantity(item, quantity);
        Debug.Log("current quantity is " + quantity + " and exceeds max: " + exceedsMax);

        if (!exceedsMax) {
            itemsList.Add(item);
            // update the current inventory after adding
            setCurrentInventoryQuantity(item);

            // check if item you added was an objective
            if (item.IsObjective) {
                Debug.Log("the item you picked up was an objective of the current quest.");
                QuestManager.currentQuest.removeQuestEntryFromCurrentQuestArray(item.ItemName);
            }
            Debug.Log("item was added.");
            return true;
        }
        if (exceedsMax) {
            Debug.Log("you reached the limit.");
            return false;
        } else {
            Debug.Log("Item couldn't be added.");
            return false;
        }

        
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
