using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MissSkyForwardRunAnimation:PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
        animationManeger.SetAirAnimation();
        animationManeger.SetJumpTag(EntityTag.MidAir);
        animationManeger.PlayerRigidbody.velocity = Vector3.zero;
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
        var isNextAir = animationManeger.IsNextAir();
        //Handlerの実装は問題ないが、タグは今後変更するので注意が必要
        if (isNextAir && isCombo && inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Sky_Attack);
        }
        else if (isNextAir && !isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
        if (isNextAir && isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky);
        }
        else if (isNextAir && !isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
    }
    public override void movePosition()
    {
        var sineMovingX = calculationSine(PlayerAnimationManeger.MissMagnification);
        animationManeger.gameObject.transform.position += new Vector3(sineMovingX, 0, 0) * GameTime.playingTime * 5f;
        animationManeger.gameObject.transform.position += new Vector3(1.0f, 0, 0) * GameTime.playingTime * 1f;
    }
}
