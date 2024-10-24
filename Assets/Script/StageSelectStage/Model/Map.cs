using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int amountStages {get; set; }
    private int movigMaxRange { get; set; }
    public List<GameObject> stages=new List<GameObject>();
    //movingMaxRange‚Ìİ’è‚ğs‚¤
    private void Awake()
    {
        amountStages=countStages();
    }
    private int countStages()
    {
        return stages.Count;
    }
    public void addMovingRange()
    {
        movigMaxRange++;
    }
}