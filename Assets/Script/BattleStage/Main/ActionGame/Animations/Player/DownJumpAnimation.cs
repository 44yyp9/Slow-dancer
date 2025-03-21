using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DownJumpAnimation : PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
    public override void movePosition()
    {
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
            animationManeger.gameObject.transform.position += new Vector3(PlayerAnimationManeger.MissMagnification, 0, 0) * GameTime.playingTime;
        }
    }
    public override void nextAnimation()
    {
        var isCombo = animationManeger.isCombo();
        var isNextAir = animationManeger.IsNextAir();
        //Idel状態に変更
        if (animationManeger.entityTag.Value == EntityTag.Ground.ToString())
        {
            transNextAnimation(PlayerAnimatioName.Idel);
        }
        //攻撃
        if (isNextAir &&isCombo && inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Sky_Attack);
        }
        else if (isNextAir && !isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
        //ダッシュ
        if (isNextAir&&isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky);
        }
        else if (isNextAir && !isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
    }
}
