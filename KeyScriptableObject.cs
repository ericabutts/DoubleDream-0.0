using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="New Key", menuName="Custom/Create Key")]
public class KeyScriptableObject : Item
{
    [SerializeField] private string keyName;
    [SerializeField] private string doorName;

    [SerializeField] private string objectToFindKey;

    // [SerializeField] private bool _isObjective;

    public string KeyName { 
        get {return keyName;}
        set {keyName = value;}
    }

    public string DoorName {
        get {return doorName;}
        set {doorName = value;}
    }

    public string ObjectToFindKey {
        // where to find this key
        get {return objectToFindKey;}
        set {objectToFindKey = value;}
    }

    // public bool isObjective {
    //     get {return _isObjective;}
    //     set { _isObjective = value;}
    // }

    public override void Use() {
        Debug.Log("using the key.");
    }

}
