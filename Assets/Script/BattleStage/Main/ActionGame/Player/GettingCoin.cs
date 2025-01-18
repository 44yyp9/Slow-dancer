using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GettingCoin : MonoBehaviour
{
    public static int havingCoin;
    public ReactiveProperty<int> totalCoin=new ReactiveProperty<int>(havingCoin);
    private void OnTriggerEnter2D(Collider2D coins)
    {
        if(coins.TryGetComponent(out Coin coin))
        {
            totalCoin.Value += coin.coinPoint;
            coin.onGetCoin();
        }
    }
}
