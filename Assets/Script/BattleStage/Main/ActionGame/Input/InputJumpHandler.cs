using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputJumpHandler : InputHandlerBase
{
    //Normal��jump�͈�ԍŌ�ɂ��Ȃ��Ƃ����Ȃ�
    private KeyCode key = KeyCode.Space;
    private KeyCode button = KeyCode.Joystick1Button1; //�~
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
