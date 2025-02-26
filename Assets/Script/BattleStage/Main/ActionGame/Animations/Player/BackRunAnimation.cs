using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BackRunAnimation : PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {

    }
    public override void movePosition()
    {

    }

}
