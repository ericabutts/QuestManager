using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Quest", menuName = "Quest System/Quest")]

[System.Serializable]
public class Quest : ScriptableObject
{
    // public bool complete;
    public TextAsset questDialogue;
    public bool questIsComplete = false;

    [SerializeField]
    public List<QuestEntry> questEntriesArray = new List<QuestEntry>();


    //quest entry data is a class used to make persistent objects in the inspector
    [SerializeField]
    public List<QuestEntryData> entryData = new List<QuestEntryData>();


    private void OnEnable()
    {
        if (entryData.Count > 0) {
            Debug.Log("Add entries to quest");
            InitializeQuestEntries(entryData);
        }
        
    }

    public void InitializeQuestEntries(List<QuestEntryData> entryDataList)
    {
        questEntriesArray.Clear();

        foreach (QuestEntryData entryData in entryDataList)
        {
            AddQuestEntry(entryData);
        }
    }

    private void AddQuestEntry(QuestEntryData entryData)
    {
        QuestEntry newEntry = new QuestEntry();
        newEntry.entryName = entryData.entryName;
        newEntry.parentQuest = this;

        questEntriesArray.Add(newEntry);
    }



    public void startQuestDialogue () {
        Debug.Log("Begin dialogue of new quest.");
        //set the new csv file in the dialogue manager
        DialogueManager.Instance.csvFile = questDialogue;
        DialogueManager.Instance.startDialogue();
    }

    public void questWasCompleted() {
        Debug.Log("Quest was completed!");
        DialogueManager.Instance.csvFile = questDialogue;
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
                Debug.Log("Remove entry.");
                questEntriesArray.Remove(entry);
                break;
            }
        }
    }

//https://gamedevbeginner.com/scriptable-objects-in-unity/#:~:text=Let's%20get%20started.-,What%20is%20a%20scriptable%20object%20in%20Unity%3F,contain%20their%20own%20unique%20values.

}
