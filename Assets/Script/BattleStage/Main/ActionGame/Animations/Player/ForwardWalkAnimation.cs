using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForwardWalkAnimation: PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movePosition();
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var isCombo=animationManeger.isCombo();
        //攻撃
        if (isCombo && inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardAttackHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        //ダッシュ
        if (isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Dash);
        }
        else if (isCombo && inputManeger.getInput<InputUpForwardJumpHandler>()) //UpJump
        {
            transNextAnimation(PlayerAnimatioName.Forward_Up_Jump);
        }
        else if (isCombo && inputManeger.getInput<InputDownForwardJumpHandler>()) //DownJump
        {
            transNextAnimation(PlayerAnimatioName.Forward_Down_Jump);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        //その場にとどまる
        if (isCombo && inputManeger.getInput<InputIdelHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Idel);
        }
        else if (!isCombo && inputManeger.getInput<InputIdelHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        //jump
        if (isCombo && inputManeger.getInput<InputJumpHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Jump);
        }
        else if (!isCombo && inputManeger.getInput<InputJumpHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        var inputIdelHandler =new InputForwardWalkHandler();
        if (inputIdelHandler.upButton())
        {
            transNextAnimation(PlayerAnimatioName.Idel);
        }
    }
    public override void movePosition()
    {
        animationManeger.gameObject.transform.position += new Vector3(PlayerAnimationManeger.WalkMagnification, 0, 0) * GameTime.playingTime;
    }

}
