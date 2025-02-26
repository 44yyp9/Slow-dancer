using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputBackAttackHandler:InputHandlerBase
{
    private KeyCode key = KeyCode.A;
    private KeyCode key2 = KeyCode.L;
    private KeyCode button = KeyCode.Joystick1Button2; //Åõ
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
        if (inputLeftPad() && Input.GetKey(button))
        {
            _ = true;
        }
        return _;
    }
}
