using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using RhythmGameScene;

public abstract class InputHandlerBase
{
    //コントローラーの入力リファレンスはhttps://docs.unity3d.com/ja/2022.3/Manual/ios-handle-game-controller-input.html
    private string DPadX = "DPadX"; //右左
    private string DPadY = "DPadY";
    //実際に判定をとるのはこのメソッド
    //例外である歩きのためにvirtualを用いる
    public virtual bool GetKey()
    {
        var isInputed =false;
        if (inputable())
        {
            isInputed = inputKey();
            if(!isInputed) isInputed =inputController();
        }
        return isInputed;
    }
    //そもそも入力ができるかできないかの判断をするロジック
    private bool inputable()
    {
        var _ =false;
        //ゲーム内時間とノーツが重なっているかかの判定
        if (GameTime.playingTime != 0 && NoteHitterModel.isOverlaping)
        {
            _ = true;
        }
        return _;
    }
    //inputの中身にキーやマウスを組み込む
    public abstract bool inputKey();
    //コントローラー入力の場合の組み込み用
    public abstract bool inputController();
    //ここは他クラスに書くのはあり
    //以降はパッド入力用のメソッド
    public bool inputRightPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadY) > 0) //Input.GetKey(KeyCode.JoystickButton5)
        {
            _ =true;
            //Debug.Log("右を入力");
        }
        return _;
    }
    public bool inputLeftPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadY)<0)
        {
            _ = true;
            //Debug.Log("左を入力");
        }
        return _;
    }
    public bool inputUpPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadX) < 0)
        {
            _ = true;
            //Debug.Log("上を入力");
        }
        return _;
    }
    public bool inputDownPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadX) > 0)
        {
            _ = true;
            //Debug.Log("下を入力");
        }
        return _;
    }
}