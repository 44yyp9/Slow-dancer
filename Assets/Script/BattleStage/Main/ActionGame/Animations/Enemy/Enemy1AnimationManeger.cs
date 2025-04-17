using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Enemy1AnimationManeger : MonoBehaviour
{
    public const int EnemyScore = 10;
    public const int EnemyDamegePoint = 20;
    [SerializeField] private Animator animator;
    private Action<Collider2D> touchingPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingPlayer?.Invoke(collision);
    }
    public void SetTouchPlayer(Action<Collider2D> action)
    {
        touchingPlayer = action;
    }
    public void DisposaleTouchPlayer()
    {
        touchingPlayer = null;
    }
    public void TransformAnimation(EnemyAnimationName name)
    {
        string _name=name.ToString();
        animator.Play(_name);
    }
}
public enum EnemyAnimationName
{
    Idel,Walk,Dead
}
