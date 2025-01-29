using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PossessionCoinPresenter : MonoBehaviour
{
    [SerializeField] private PossessionCoinModel model;
    [SerializeField] private PossessionCoinView view;
    private void Start()
    {
        model.possessionCoin.Subscribe(_ => view.possessionCoin = model.possessionCoin).AddTo(this);
        model.readCoin();
        view.desplayCoin();
    }
}
