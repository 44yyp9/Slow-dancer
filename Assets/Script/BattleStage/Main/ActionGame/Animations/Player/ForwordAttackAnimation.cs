using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForwordAttackAnimation :  PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setAnimationManeger(animator);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var inputWalk = new InputForwardWalkHandler();
        if (inputWalk.GetKey())
        {
            animationManeger.playerAnimator.Play("A_walk");
        }
        //ここのコードは修正必須
        if (Input.GetKeyDown(KeyCode.S))
        {
            animationManeger.playerAnimator.Play("A_idle");
        }
    }
}
