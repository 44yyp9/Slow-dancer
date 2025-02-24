using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AnimationManegerBase : MonoBehaviour
{
    public void stopAnimation(Animator animator)
    {
        if (GameTime.playingTime == 0)
        {
            animator.speed = 0;
        }
    }
}
