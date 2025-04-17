using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WalkEnemyAnimation : EnemyAnimationBase
{
    private const float MoveX = -5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetManeger(animator);
        animationManeger.SetTouchPlayer(OnPlayer);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void NextAnimation()
    {
        animationManeger.TransformAnimation(EnemyAnimationName.Dead);
    }
    public override void Move()
    {
        animationManeger.gameObject.transform.position += new Vector3(MoveX, 0, 0) * GameTime.playingTime;
    }
    public void OnPlayer(Collider2D player)
    {
        if (player.gameObject.tag == EntityTag.Player.ToString())
        {
            var playerObj= player.gameObject;
            if(playerObj.TryGetComponent<PlayerAnimationManeger>(out PlayerAnimationManeger playerManeger))
            {
                //playerManeger�̎擾
                var playerTag = playerManeger.playerTag.Value;
                //player�̏�Ԃ̊m�F
                if (playerTag == PlayerTag.Attaking)
                {
                    NextAnimation();
                    //���̃��\�b�h�̔j��
                    animationManeger.DisposaleTouchPlayer();
                }
                if (playerTag == PlayerTag.Normal)
                {
                    playerManeger.ApplyDamege(Enemy1AnimationManeger.EnemyDamegePoint);
                }
            }
        }
    }
}
