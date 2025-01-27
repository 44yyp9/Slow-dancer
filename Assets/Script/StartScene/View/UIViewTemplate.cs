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
    /// �z�o�[�̏���
    /// </summary>
    ///�}�E�X���N�������Ƃ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterMouseButton(eventData);
    }
    //�}�E�X���o�Ă������Ƃ�
    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitMouseButton(eventData);
    }
    public virtual void OnEnterMouseButton(PointerEventData eventData)
    {
        //�K�v�ɉ����ăI�[�o�[���C�h����
    }
    public virtual void OnExitMouseButton(PointerEventData eventData)
    {
        //�K�v�ɉ����ăI�[�o�[���C�h����
    }
}
