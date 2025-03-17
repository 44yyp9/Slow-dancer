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
        var sineMovingX = calculationSine(3f);
        animationManeger.gameObject.transform.position += new Vector3(sineMovingX, 0, 0) * GameTime.playingTime * 10f;
        animationManeger.gameObject.transform.position += new Vector3(1.0f, 0, 0) * GameTime.playingTime * 2f;
    }

}
