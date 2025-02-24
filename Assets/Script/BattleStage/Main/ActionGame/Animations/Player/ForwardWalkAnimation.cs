using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForwardWalkAnimation: PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setAnimationManeger(animator);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animationManeger.gameObject.transform.position +=new Vector3(1,0,0) * GameTime.playingTime;
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var inputAttack=new InputForwardAttackHandler();
        if (inputAttack.GetKey())
        {
            animationManeger.playerAnimator.Play("A_Attac_horizon");
        }
        //Ç±Ç±Ç‡èCê≥ïKê{
        if (Input.GetKeyDown(KeyCode.S))
        {
            animationManeger.playerAnimator.Play("A_idle");
        }
    }
}
