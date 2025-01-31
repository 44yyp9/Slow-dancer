using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UIViewTemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Button button;
    public void clicked(Action onButtonClicked)
    {
        button.onClick.AddListener(() => onButtonClicked?.Invoke());
    }
    /// <summary>
    /// ホバーの処理
    /// </summary>
    ///マウスが侵入したとき
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterMouseButton(eventData);
    }
    //マウスが出ていったとき
    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitMouseButton(eventData);
    }
    public virtual void OnEnterMouseButton(PointerEventData eventData)
    {
        //必要に応じてオーバーライドする
    }
    public virtual void OnExitMouseButton(PointerEventData eventData)
    {
        //必要に応じてオーバーライドする
    }
}
