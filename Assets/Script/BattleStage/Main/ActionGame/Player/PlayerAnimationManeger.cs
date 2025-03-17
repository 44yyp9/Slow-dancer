using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class PlayerAnimationManeger:AnimationManegerBase
{
    public Animator playerAnimator;
    public ReactiveProperty<bool> comboing;
    public ReactiveProperty<int> playerHP;
    public ReactiveProperty<PlayerTag> playerTag;
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
        this.playerTag.Value = tag;
    }
    public void gameClear()
    {

    }
    public void gameOver()
    {

    }
    private void Start()
    {
        //�Q�[���J�n���̃^�O�̐ݒ�
        setTag(PlayerTag.Normal);
        playerTag.Subscribe(_ =>HandleDamege()).AddTo(this);
    }
    //Enemy���A�N�Z�X����悤�̃��\�b�h
    public void ApplyDamege(int damagePoint)
    {
        setTag(PlayerTag.Damageing);
        playerHP.Value -= damagePoint;
    }
    //player�p�̃��\�b�h
    private async void HandleDamege()
    {
        if (playerTag.Value == PlayerTag.Damageing)
        {
            //1�b�ԑҋ@
            await UniTask.Delay(1000);
            //�����o�O�肻��
            setTag(PlayerTag.Normal);
        }
    }
}
public enum PlayerTag
{
    Normal, //���ʂ̏��
    Attaking, //�U�����Ă�����
    Damageing //�_���[�W���󂯂Ă�����
}
public enum PlayerAnimatioName
{
    Idel,Jump, Forward_Ground_Attack, Back_Ground_Attack, Forward_Walk,Back_Walk,
    Forward_Run_Sky, Back_Run_Sky, Miss_Forward_Run_Sky, Miss_Back_Run_Sky

}
public enum EntityTag
{
    Player,Enemy,Ground,Goal
}