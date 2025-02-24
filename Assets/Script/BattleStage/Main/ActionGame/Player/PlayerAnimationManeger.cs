using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerAnimationManeger:AnimationManegerBase
{
    public Animator playerAnimator;
    public ReactiveProperty<bool> comboing;
    public ReactiveProperty<int> playerHP;
    public PlayerTag playerTag;
    public bool isCombo()
    {
        return comboing.Value;
    }
    public int isPlayerHP()
    {
        return playerHP.Value;
    }
    public void setTag(PlayerTag tag)
    {
        this.playerTag = tag;
    }
    public void gameClear()
    {

    }
    public void gameOver()
    {

    }
}
public enum PlayerTag
{
    Normal, //���ʂ̏��
    Attaking, //�U�����Ă�����
    Damageing //�_���[�W���󂯂Ă�����
}