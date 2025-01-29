using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GettingCoin : MonoBehaviour
{
    public ReactiveProperty<int> totalCoin=new ReactiveProperty<int>(PossessionCoin.possessionCoin);
    private void OnTriggerEnter2D(Collider2D coins)
    {
        if(coins.TryGetComponent(out Coin coin))
        {
            totalCoin.Value += coin.coinPoint;
            var coinController = new PossessionCoin();
            coinController.addCoin(coin.coinPoint);
            coin.onGetCoin();
        }
    }
}
