using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputJumpHandler : InputHandlerBase
{
    //NormalÇÃjumpÇÕàÍî‘ç≈å„Ç…ÇµÇ»Ç¢Ç∆Ç¢ÇØÇ»Ç¢
    private KeyCode key = KeyCode.Space;
    private KeyCode button = KeyCode.Joystick1Button1; //Å~
    public override bool inputKey()
    {
        var _ = false;
        if (Input.GetKey(key))
        {
            _ = true;
        }
        return _;
    }
    public override bool inputController()
    {
        var _ = false;
        if (Input.GetKey(button))
        {
            _ = true;
        }
        return _;
    }
}
