using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IdelAnimation : PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("idel");
    }
    public override void nextAnimation()
    {
        var isCombo = animationManeger.isCombo();
        //インスタンスの生成
        var inputForwardWalkHandler=new InputForwardWalkHandler();
        //入力の実装
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk.ToString());
        }
        if (inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack.ToString());
        }
        if (isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //実際はjamp中しかできないので注意
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky.ToString());
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //実際はjamp中しかできないので注意
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky.ToString());
        }
        if (inputManeger.getInput<InputIdelHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
        }
    }
    public override void movePosition()
    {
        //移動はしない
    }
}
