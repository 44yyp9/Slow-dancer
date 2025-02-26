using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IdelAnimation : PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setAnimationManeger(animator);
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
        //インスタンスの生成
        var inputForwardWalkHandler = new InputForwardWalkHandler();
        //入力の実装
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk.ToString());
        }
        var inputForwardAttackHandler = new InputForwardAttackHandler();
        if (inputForwardAttackHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack.ToString());
        }
      　var inputIdelHandler= new InputIdelHandler();
        if (inputIdelHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
        }
    }
    public override void movePosition()
    {
        //移動はしない
    }
}
