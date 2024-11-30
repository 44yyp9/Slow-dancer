using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ComboSender : MonoBehaviour
{
    [SerializeField] private Combo combo;
    [SerializeField] private UIComboModel uiComboModel;
    private void Start()
    {
        combo.combo.Subscribe(_ => uiComboModel.combo = combo.combo).AddTo(this);
        combo.isCombo.Subscribe(_ =>uiComboModel.isCombo=combo.isCombo).AddTo(this);
    }
}
