using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StageScorePresenter : MonoBehaviour
{
    [SerializeField] private StageScoreModel model;
    [SerializeField] private StageScoreView view;
    private void Start()
    {
        model.stageCleared.Subscribe(_ => view.stageCleared.Value = model.stageCleared.Value).AddTo(this);
        model.highScore.Subscribe(_ => view.highScore.Value = model.highScore.Value).AddTo(this);
        model.secondScore.Subscribe(_ => view.secondScore.Value = model.secondScore.Value).AddTo(this);
        model.thirdScore.Subscribe(_ => view.thirdScore.Value = model.thirdScore.Value).AddTo(this);
    }
}
