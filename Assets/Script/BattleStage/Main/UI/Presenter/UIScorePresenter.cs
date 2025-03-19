using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIScorePresenter : MonoBehaviour
{
    [SerializeField] private UIScoreModel model;
    [SerializeField] private UIScoreView view;
    private void Start()
    {
        subscribeScore();
    }
    private void subscribeScore()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition: () => model.score != null && view.viewPoint != null,
            subscribe: () =>
            {
                model.score.Subscribe(_ => view.viewPoint = model.score).AddTo(this);
                model.score.Subscribe(_ =>view.setScoreValue(model.IsSliderValue())).AddTo(this);
            }
            ));
    }
}
