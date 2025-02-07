using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultScorePresenter : MonoBehaviour
{
    [SerializeField] private ResultScoreModel model;
    [SerializeField] private ResultScoreView view;
    private void Start()
    {
        model.score.Subscribe(_ => view.score.Value = model.score.Value).AddTo(this);
        model.rank.Subscribe(_ => view.rank.Value = model.rank.Value).AddTo(this);
        model.setResult();
        view.showResult();
    }
}
