using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForwordAttackAnimation :  PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setAnimationManeger(animator);
        setAnimationSpeed(stateInfo.length);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setSineAnimation();
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var inputWalk = new InputForwardWalkHandler();
        if (inputWalk.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Walk.ToString());
        }
        var inputForwardAttackHandler = new InputForwardAttackHandler();
        if (inputForwardAttackHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack.ToString());
        }
        var inputForwardRunHandler = new InputForwardRunHandler();
        if (inputForwardRunHandler.GetKey())
        {
            //é¿ç€ÇÕjampíÜÇµÇ©Ç≈Ç´Ç»Ç¢ÇÃÇ≈íçà”
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky.ToString());
        }
        var inputIdelHandler = new InputIdelHandler();
        if (inputIdelHandler.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
        }
    }
    public override void movePosition()
    {

    }

}
