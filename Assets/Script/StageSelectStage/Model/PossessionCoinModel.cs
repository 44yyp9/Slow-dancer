using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PossessionCoinModel : MonoBehaviour
{
    public ReactiveProperty<int> possessionCoin;
    public void readCoin()
    {
        possessionCoin.Value = PossessionCoin.possessionCoin;
    }
}
