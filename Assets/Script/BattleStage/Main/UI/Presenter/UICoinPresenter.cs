using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UICoinPresenter : MonoBehaviour
{
    [SerializeField] private UICoinModel coinModel;
    [SerializeField] private UICoinView coinView;
    private void Start()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition: () => coinView.viewPoint != null && coinModel.totalCoin != null,
            subscribe: () =>
            {
                coinModel.totalCoin.Subscribe(_ => coinView.viewPoint = coinModel.totalCoin).AddTo(this);
            }
            ));
    }

}
