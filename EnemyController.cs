using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController : MonoBehaviour, IInteractable
{
    [SerializeField] public string enemyMessage;

    public string message
    {
        get { return enemyMessage; }
        set { enemyMessage = value; }
    }

    public bool hasBeenClicked { get; set; } = false;

    public string name { get; set; }

    [SerializeField] public bool _isObjective;
    public bool isObjective {
        get {return _isObjective;}
        set {isObjective = _isObjective;}
    }

    public Transform player;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public void Die() {
        Debug.Log("Kill this enemy.");
        this.gameObject.SetActive(false);
    }

    public void Interact() {
        DialogueManager.Instance.playObjectMessage(message);
        // remove quest entry if is objective 
        if (isObjective) {
            QuestManager.currentQuest.removeQuestEntryFromCurrentQuestArray(this.gameObject.name);
        }
        Die();
    }



    // Start is called before the first frame update
    void Start()
    {
        //set the attribute directly on this class
        //gameObject.GetComponent<IInteractable>().message = myMessage;
        player = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    public void Update() {
        if(Vector3.Distance(transform.position, player.position)< 10f) {
            navMeshAgent.SetDestination(player.position);
        }
    }

}
