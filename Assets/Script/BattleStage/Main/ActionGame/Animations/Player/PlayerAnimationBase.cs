using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class PlayerAnimationBase:StateMachineBehaviour
{
    public PlayerAnimationManeger animationManeger;
    public void setAnimationManeger(Animator animator)
    {
        animationManeger=animator.GetComponent<PlayerAnimationManeger>();
    }
    public void deadAnimation()
    {
        if (animationManeger.isPlayerHP() <= 0)
        {
            //ここに死亡アニメーションを流す実装をする
            animationManeger.playerAnimator.Play("");
        }
    }
    public abstract void nextAnimation();
}
