using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPosition : MonoBehaviour
{
    public ReactiveProperty<int> currentStage { get; set; } = new ReactiveProperty<int>(0);
    [SerializeField] private Map map;
    public void addStage()
    {
        if (map.movigMaxRange == currentStage.Value + 1 ) return;
        currentStage.Value++;
    }
    public void backStage()
    {
        if ( 0 > currentStage.Value - 1) return;
        currentStage.Value--;
    }
    //currentStage‚Ì‰Šú’l‚Ìİ’è
    private void Start()
    {

    }
}
