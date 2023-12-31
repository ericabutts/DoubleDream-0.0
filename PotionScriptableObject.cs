using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName="New Potion", menuName="Custom/Create Potion")]
public class PotionScriptableObject : Item
{
    [SerializeField] private int healthToIncrease;

    public int HealthToIncrease {
        get { return healthToIncrease; }
        set { healthToIncrease = value; }
    }

    
}
