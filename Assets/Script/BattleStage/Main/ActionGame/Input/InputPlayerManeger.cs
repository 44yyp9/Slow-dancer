using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputPlayerManeger
{
    private List<InputHandlerBase> inputHandlers;
    public InputPlayerManeger()
    {
        inputHandlers = new List<InputHandlerBase>
        {
            //InputHanlerBase‚ğŒp³‚µ‚Ä‚éƒNƒ‰ƒX‚Í‘S‚Ä‘‚­
            new InputForwardRunHandler(),
            new InputIdelHandler(),
            new InputForwardAttackHandler(),
        };
    }
    public bool inputHandler()
    {
        var _ = false;
        foreach (var handler in inputHandlers)
        {
            _ = handler.GetKey();
            if (_) break;
        }
        return _;
    }
}

