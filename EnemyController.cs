using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController : MonoBehaviour, IInteractable
{

    public string message { get; set; }

    public string myMessage;

    public bool hasBeenClicked { get; set; } = false;

    public string name { get; set; }

    public bool isObjective {get; set;} = true;

    public void Interact() {
        DialogueManager.Instance.playObjectMessage(message);
        if (isObjective) {
            QuestManager.currentQuest.removeQuestEntryFromCurrentQuestArray(this.gameObject.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<IInteractable>().message = myMessage;
        
    }

}
