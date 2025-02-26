using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputUpBackJumpHandler : InputHandlerBase
{
    private KeyCode key = KeyCode.S;
    private KeyCode key2 = KeyCode.D;
    private KeyCode key3 = KeyCode.Space;
    private KeyCode button = KeyCode.Joystick1Button0; //Å†
    public override bool inputKey()
    {
        var _ = false;
        if (Input.GetKey(key) && Input.GetKey(key2)&&Input.GetKey(key3))
        {
            _ = true;
        }
        return _;
    }
    public override bool inputController()
    {
        var _ = false;
        if (inputRightPad() &&inputDownPad()&& Input.GetKey(button))
        {
            _ = true;
        }
        return _;
    }
}
