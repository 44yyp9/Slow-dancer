using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class JumpAnimation : PlayerAnimationBase
{
    private bool _isJumping;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isJumping = true;
        setManeger(animator);
        setAnimationSpeed(stateInfo.length*3);
        animationManeger.SetJumpTag(EntityTag.Air);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextAnimation();
        movePosition();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var isCombo = animationManeger.isCombo();
        //攻撃
        if (isCombo && inputManeger.getInput<InputForwardAttackHandler>())
        {
            //ここは空中攻撃に後に変更する
            transNextAnimation(PlayerAnimatioName.Forward_Sky_Attack);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
        //空中では再ジャンプ禁止
        //ダッシュ
        if (isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>()) //ミス移動
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
    }
    public override void movePosition()
    {
        if (_isJumping)
        {
            animationManeger.PlayerRigidbody.AddForce(new Vector2(0, PlayerAnimationManeger.RunMagnification*2), ForceMode2D.Impulse);
            _isJumping = false;
        }
        MoveLeft();
        MoveRigth();
    }
    private void MoveLeft()
    {
        if (Input.GetAxis("DPadY") < 0)
        {
            animationManeger.gameObject.transform.position += new Vector3(-1 * PlayerAnimationManeger.MissMagnification, 0, 0) * GameTime.playingTime;
        }
    }
    private void MoveRigth()
    {
        if (Input.GetAxis("DPadY") > 0)
        {
            animationManeger.gameObject.transform.position += new Vector3(PlayerAnimationManeger.MissMagnification, 0, 0) * GameTime.playingTime ;
        }
    }
}
