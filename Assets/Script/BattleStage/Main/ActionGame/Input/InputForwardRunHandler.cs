using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputForwardRunHandler : InputHandlerBase
{
    private KeyCode key = KeyCode.D;
    private KeyCode key2 = KeyCode.K;
    private KeyCode button = KeyCode.Joystick1Button0; //Å†
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
}
