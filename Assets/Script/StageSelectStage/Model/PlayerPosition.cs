using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    int currentStage { get; set; }
    public void addStage()
    {
        currentStage++;
    }
    public void backStage()
    {
        currentStage--;
    }
    //currentStage‚Ì‰Šú’l‚Ìİ’è
    private void Awake()
    {
        
    }
}
