using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
// [CreateAssetMenu]
public class QuestEntry : ScriptableObject
{

    public bool entryIsComplete = false;
    public string entryName;

    //add a reference to the Quest the entry belongs to.
    public Quest parentQuest;
    public string objectiveDescription;



    public void objectiveWasCompleted() {
        Debug.Log("You completed one objective.");
        entryIsComplete = true;
    }
    
}
