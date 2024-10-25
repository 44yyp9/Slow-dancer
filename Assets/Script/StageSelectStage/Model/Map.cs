using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int amountStages {get; set; }
    public int movigMaxRange { get; set; }
    public List<GameObject> stages=new List<GameObject>();
    private void Awake()
    {
        amountStages=countStages();
        //movingMaxRange�̐ݒ���s��(�Ƃ肠�������~��)
        movigMaxRange = amountStages;
    }
    private int countStages()
    {
        return stages.Count;
    }
    public void addMovingRange()
    {
        if (amountStages == movigMaxRange) return;
        movigMaxRange++;
    }
}