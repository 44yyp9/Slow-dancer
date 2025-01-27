using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.EventSystems;

public class GameStartingView : UIViewTemplate
{
    public override void OnEnterMouseButton(PointerEventData eventData)
    {
        Debug.Log("スタートボタンに侵入しました");
    }
    public override void OnExitMouseButton(PointerEventData eventData)
    {
        Debug.Log("スタートボタンから出ていきました");
    }

}
