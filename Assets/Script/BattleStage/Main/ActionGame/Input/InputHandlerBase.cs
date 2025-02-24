using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class InputHandlerBase
{
    //実際に判定をとるのはこのメソッド
    public bool GetKey()
    {
        var _ =false;
        if (GameTime.playingTime != 0)
        {
            _ = input();
        }
        return _;
    }
    //inputの中身にキーやマウスを組み込む
    public abstract bool input();
}
