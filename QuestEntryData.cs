using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestEntryData
{
    public bool entryIsComplete = false;
    public string entryName;

    //add a reference to the Quest the entry belongs to.
    public Quest parentQuest;
    public string objectiveDescription;



}
