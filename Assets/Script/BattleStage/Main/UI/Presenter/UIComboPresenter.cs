using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Burst.Intrinsics;

public class UIComboPresenter : MonoBehaviour
{
    [SerializeField] private UIComboModel comboModel;
    [SerializeField] private UIComboView comboView;
    private void Start()
    {
        isComboSubscribe();
        comboPointSubscribe();
    }
    private void comboPointSubscribe()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
        condition: () => comboView.viewPoint != null && comboModel.combo != null,
        subscribe: () =>
        {
            comboModel.combo.Subscribe(_ => comboView.viewPoint = comboModel.combo).AddTo(this);
        }));
    }
    private void isComboSubscribe()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition: () => comboView.isCombo != null && comboModel.isCombo != null,
            subscribe: () =>
            {
                comboModel.isCombo.Subscribe(_ => comboView.isCombo = comboModel.isCombo).AddTo(this);
            }));
    }
}
