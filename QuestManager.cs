using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;
    public static Quest currentQuest;
    public int questNumber;
    public List<Quest> questList;

    public void advanceToNextQuest() {
        Debug.Log("Advance to next quest.");
        questNumber += 1;
        currentQuest = questList[questNumber];
        
    }

    void Awake() {
        if (questManager == null) {
            questManager = this;
        } else if (questManager != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        currentQuest = questList[questNumber];
    }
}
