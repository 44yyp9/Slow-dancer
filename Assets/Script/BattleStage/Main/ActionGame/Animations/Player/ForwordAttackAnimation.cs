using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForwordAttackAnimation :  PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
        animationManeger.setTag(PlayerTag.Attaking);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //setSineAnimation();
        movePosition();
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManeger.setTag(PlayerTag.Normal);
    }
    public override void nextAnimation()
    {
        var isCombo = animationManeger.isCombo();
        //�C���X�^���X�̐���
        var inputForwardWalkHandler = new InputForwardWalkHandler();
        //���͂̎���
        //����
        if (inputForwardWalkHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk);
        }
        //�U��
        if (isCombo && inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>()) //�~�X�ړ�
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
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
        else if (!isCombo && inputManeger.getInput<InputIdelHandler>()) //�~�X�ړ�
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
        //jump
        if (isCombo && inputManeger.getInput<InputJumpHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Jump);
        }
        else if (!isCombo && inputManeger.getInput<InputJumpHandler>()) //�~�X�ړ�
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Dash);
        }
    }
    public override void movePosition()
    {
        var sineMovingX = calculationSine(PlayerAnimationManeger.RunMagnification);
        animationManeger.gameObject.transform.position += new Vector3(sineMovingX, 0, 0) * GameTime.playingTime * 10f;
        animationManeger.gameObject.transform.position += new Vector3(1.0f, 0, 0) * GameTime.playingTime * 2f;
    }

}
