using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest : ScriptableObject
{
    // public bool complete;
    public TextAsset questDialogue;
    public bool questIsComplete = false;
    public List<QuestEntry> questEntriesArray;
    List<QuestEntry> newQuestEntriesArray;

    public void startQuestDialogue () {
        Debug.Log("Begin dialogue of new quest.");
        DialogueManager.Instance.startDialogue(questDialogue);
    }

    public void questWasCompleted() {
        Debug.Log("Quest was completed!");
        QuestManager.currentQuest.startQuestDialogue();
        QuestManager.questManager.advanceToNextQuest();
        
    }
    

    public void removeQuestEntryFromCurrentQuestArray(string gameObjectName) {
        if (questEntriesArray.Count == 0) {
            return;
        }
        foreach (var entry in questEntriesArray) {
            if (gameObjectName.Equals(entry.entryName)) {
                if (questEntriesArray.Count == 1) {
                    Debug.Log("You completed the entries!");
                    questIsComplete = true;
                    questWasCompleted();
                }
                questEntriesArray.Remove(entry);
                break;
            }
        }
    }

//https://gamedevbeginner.com/scriptable-objects-in-unity/#:~:text=Let's%20get%20started.-,What%20is%20a%20scriptable%20object%20in%20Unity%3F,contain%20their%20own%20unique%20values.

}
