using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PossessionCoin
{
    public static int possessionCoin = 0;//���u���悤�̒l
    public void addCoin(int coin)
    {
        possessionCoin += coin;
    }
    public void removeCoin(int coin)
    {
        possessionCoin -= coin;
    }
}
