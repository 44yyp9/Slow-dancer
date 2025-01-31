using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class DecisionStageView : MonoBehaviour
{
    private Action onDecistionKey;
    public void InputDecisionStage()
    {
        //ƒL[‚Ì“o˜^
        Observable.EveryUpdate()
        .Where(_ => Input.GetKeyDown(KeyCode.Space))
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onDecistionKey?.Invoke();
            }
        })
        .AddTo(this);
    }
    //À‘•‚·‚éˆ—‚ğPresenter‚ğ’Ê‚µ‚Ä“o˜^
    public void registerKeyAction(Action onDecistionKey)
    {
        this.onDecistionKey=onDecistionKey;
    }
    private void Start()
    {
        InputDecisionStage();
    }
}
