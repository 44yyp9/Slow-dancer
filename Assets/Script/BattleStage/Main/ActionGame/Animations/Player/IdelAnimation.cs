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
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk);
        }
        if (inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack);
        }
        if (isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //���ۂ�jamp�������ł��Ȃ��̂Œ���
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //���ۂ�jamp�������ł��Ȃ��̂Œ���
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
        if (inputManeger.getInput<InputIdelHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Idel);
        }
    }
    public override void movePosition()
    {
        //�ړ��͂��Ȃ�
    }
}
