using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoinPointSender : MonoBehaviour
{
    [SerializeField] private GettingCoin gettingCoin;
    [SerializeField] private UICoinModel uiCoinModel;
    private void Start()
    {
        gettingCoin.totalCoin.Subscribe(_ => uiCoinModel.totalCoin=gettingCoin.totalCoin).AddTo(this);
    }
}
