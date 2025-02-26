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
        var inputAttack=new InputForwardAttackHandler();
        if (inputAttack.GetKey())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack.ToString());
        }
        var inputForwardRunHandler = new InputForwardRunHandler();
        if (isCombo&&inputForwardRunHandler.GetKey())
        {
            //é¿ç€ÇÕjampíÜÇµÇ©Ç≈Ç´Ç»Ç¢ÇÃÇ≈íçà”
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky.ToString());
        }
        else if (!isCombo&&inputForwardRunHandler.GetKey())
        {
            //é¿ç€ÇÕjampíÜÇµÇ©Ç≈Ç´Ç»Ç¢ÇÃÇ≈íçà”
            Debug.Log(PlayerAnimatioName.Miss_Forward_Run_Sky.ToString());
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky.ToString());
        }
        var inputIdelHandler =new InputForwardWalkHandler();
        if (inputIdelHandler.upButton())
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
        }
    }
    public override void movePosition()
    {
        animationManeger.gameObject.transform.position += new Vector3(1, 0, 0) * GameTime.playingTime;
    }

}
