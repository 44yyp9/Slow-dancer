using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Coin : MonoBehaviour,IGetingCoinable
{
    public int coinPoint;
    public void onGetCoin()
    {
        gameObject.SetActive(false);
    }
}
