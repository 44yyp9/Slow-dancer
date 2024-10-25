using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ViewDefineStage : MonoBehaviour
{
    [SerializeField] private DefineStagePresenter presenter;
    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Subscribe(_ => presenter.defineStage()).AddTo(this);
    }
}
