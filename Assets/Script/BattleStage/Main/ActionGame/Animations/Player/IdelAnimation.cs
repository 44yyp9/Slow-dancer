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
        //�C���X�^���X�̐���
        var inputForwardWalkHandler=new InputForwardWalkHandler();
        //���͂̎���
        //����
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk);
        }
        //�U��
        if (inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack);
        }
        //�_�b�V��
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
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>()) //�~�X�ړ�
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        //���̏�ɂƂǂ܂�
        if (isCombo && inputManeger.getInput<InputIdelHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Idel);
        }
        //jump
        if (isCombo && inputManeger.getInput<InputJumpHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Jump);
        }
    }
    public override void movePosition()
    {
        //�ړ��͂��Ȃ�
    }
}
