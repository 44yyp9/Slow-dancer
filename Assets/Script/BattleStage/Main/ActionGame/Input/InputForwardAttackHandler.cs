using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputForwardAttackHandler : InputHandlerBase
{
    private KeyCode key = KeyCode.J;
    public override bool input()
    {
        var _ = false;
        if (Input.GetKeyDown(key))
        {
            _ = true;
        }
        return _;
    }
}
