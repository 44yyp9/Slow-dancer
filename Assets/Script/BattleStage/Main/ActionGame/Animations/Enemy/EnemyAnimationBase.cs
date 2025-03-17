using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class EnemyAnimationBase:StateMachineBehaviour
{
    public Enemy1AnimationManeger animationManeger;
    
    public void SetManeger(Animator animator)
    {
        animationManeger=animator.GetComponent<Enemy1AnimationManeger>();
    }
    public abstract void NextAnimation();
    public abstract void Move();
}
