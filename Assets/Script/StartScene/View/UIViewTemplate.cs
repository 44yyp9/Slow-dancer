using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;

public abstract class UIViewTemplate : MonoBehaviour
{
    [SerializeField] public Button button;
    public void clicked(Action onButtonClicked)
    {
        button.onClick.AddListener(() => onButtonClicked?.Invoke());
    }
}
