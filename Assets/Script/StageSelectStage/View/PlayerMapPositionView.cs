using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PlayerMapPositionView : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    public ReactiveProperty<Vector3> playerPosition;
    public void moveAnimetion(Vector3 previousPosition,Vector3 presentPosition)
    {
        //ここにアニメーションの実装
    }
    public void setPlayerPosition()
    {
        playerObject.transform.position=playerPosition.Value;
    }
    private Action onRithtArrowKey;
    private Action onLeftArrowKey;
    //キーの検知を行う
    private void InputChangePosition()
    {
        //キーの登録
        Observable.EveryUpdate()
        .Where(_ => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onRithtArrowKey?.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onLeftArrowKey?.Invoke();
            }
            setPlayerPosition();
        })
        .AddTo(this);
    }
    //presenterで発火させるようのメソッド
    public void registerKeyActions(Action onRithtArrowKey,Action onLeftArrowKey)
    {
        this.onRithtArrowKey = onRithtArrowKey;
        this.onLeftArrowKey = onLeftArrowKey;
    }
    private void Start()
    {
        InputChangePosition();
    }
}
