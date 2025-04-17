using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputForwardWalkHandler : InputHandlerBase
{
    private KeyCode key = KeyCode.D;
    private KeyCode key2 = KeyCode.O;
    private KeyCode button = KeyCode.Joystick1Button5; //R1
    public override bool inputKey()
    {
        var _ = false;
        if (Input.GetKey(key) && Input.GetKey(key2))
        {
            _ = true;
        }
        return _;
    }
    public override bool inputController()
    {
        var _ = false;
        if (inputRightPad() && Input.GetKey(button))
        {
            _ = true;
        }
        return _;
    }
    //歩きメソッドはどこでも打てる用にoverrideする
    public override bool GetKey()
    {
        var isInputed = false;
        //一時停止状態かの確認
        if (GameTime.playingTime!=0)
        {
            isInputed = inputKey();
            if (!isInputed) isInputed = inputController();
        }
        return isInputed;
    }
    //Solid原則的にここか？とはなるが
    //歩いいる状態からIdel状態に移行するための特別なメソッド
    public bool upButton()
    {
        var isInputed = false;
        //一時停止状態かの確認
        if (GameTime.playingTime != 0)
        {
            isInputed = upKey();
            if (!isInputed) isInputed = upController();
        }
        return isInputed;
    }
    private bool upKey()
    {
        var _ = false;
        if (Input.GetKeyUp(key) && Input.GetKeyUp(key2))
        {
            _ = true;
        }
        return _;
    }
    private bool upController()
    {
        var _ = false;
        if (Input.GetKeyUp(button))
        {
            _ = true;
        }
        return _;
    }
}