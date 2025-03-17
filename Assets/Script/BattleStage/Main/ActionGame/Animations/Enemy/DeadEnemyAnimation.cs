using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DeadEnemyAnimation : EnemyAnimationBase
{
    private float _Time;
    private const float FeadTime = 5;
    private const float BaseMoveX = 10f;
    private const float BaseMoveY = 10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _Time = 0;
        SetManeger(animator);
        SetAnimationSpeed(animator, stateInfo);
        SetDeadSetting();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NextAnimation();
        Move();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void NextAnimation()
    {
        _Time += GameTime.playingTime;
        if (_Time > FeadTime)
        {
            animationManeger.gameObject.SetActive(false);
        }
    }
    private void SetAnimationSpeed(Animator animator ,AnimatorStateInfo stateInfo)
    {
        var animationTime = FeadTime;
        var baseTime = stateInfo.length;
        var magnification = baseTime / animationTime;
        animator.speed*=magnification;
    }
    private void SetDeadSetting()
    {
        var collider=animationManeger.gameObject.GetComponent<Collider2D>();
        //当たり判定を無しにする
        collider.enabled = false;
    }
    public override void Move()
    {
        var magnification = (FeadTime - _Time) / FeadTime;
        float moveX = BaseMoveX * (magnification + 1);
        float moveY = BaseMoveY * (magnification + 1);
        //DoTweenで画面外に飛ばすアニメーションの実装
        animationManeger.gameObject.transform.position += new Vector3(moveX, moveY, 0) * GameTime.playingTime;
    }
}
