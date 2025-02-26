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
        var isCombo = animationManeger.isCombo();
        //�C���X�^���X�̐���
        var inputForwardWalkHandler = new InputForwardWalkHandler();
        //���͂̎���
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk.ToString());
        }
        var inputForwardAttackHandler = new InputForwardAttackHandler();
        if (inputForwardAttackHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack.ToString());
        }
        var inputForwardRunHandler =new InputForwardRunHandler();
        if (isCombo && inputForwardRunHandler.GetKey())
        {
            //���ۂ�jamp�������ł��Ȃ��̂Œ���
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky.ToString());
        }
        else if (!isCombo && inputForwardRunHandler.GetKey())
        {
            //���ۂ�jamp�������ł��Ȃ��̂Œ���
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky.ToString());
            //transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky.ToString());
        }
        var inputIdelHandler = new InputIdelHandler();
        if (inputIdelHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
        }
    }
    public override void movePosition()
    {
        //�ړ��͂��Ȃ�
    }
}
