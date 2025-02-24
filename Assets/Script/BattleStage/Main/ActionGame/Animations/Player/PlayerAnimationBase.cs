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
            //�����Ɏ��S�A�j���[�V�����𗬂�����������
            animationManeger.playerAnimator.Play("");
        }
    }
    public abstract void nextAnimation();
}
