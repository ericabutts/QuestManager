using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[CreateAssetMenu]
public class QuestEntry : ScriptableObject
{

    public bool entryIsComplete = false;
    public string entryName;


    public void objectiveWasCompleted() {
        Debug.Log("You completed one objective.");
        entryIsComplete = true;
    }
    
}
