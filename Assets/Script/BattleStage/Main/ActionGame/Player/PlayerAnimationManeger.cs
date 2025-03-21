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
    private Rigidbody2D PlayerRigidbody;
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
        //ゲーム開始時のタグの設定
        setTag(PlayerTag.Normal);
        playerTag.Subscribe(_ =>HandleDamege()).AddTo(this);
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }
    //Enemyがアクセスするようのメソッド
    public void ApplyDamege(int damagePoint)
    {
        setTag(PlayerTag.Damageing);
        playerHP.Value -= damagePoint;
    }
    //player用のメソッド
    private async void HandleDamege()
    {
        if (playerTag.Value == PlayerTag.Damageing)
        {
            //1秒間待機
            await UniTask.Delay(1000);
            //ここバグりそう
            setTag(PlayerTag.Normal);
        }
    }
    public void ForceGravity()
    {
        PlayerRigidbody.gravityScale = 1.0f;
    }
    public void FloatgGravity()
    {
        PlayerRigidbody.gravityScale = 0f;
    }
}
public enum PlayerTag
{
    Normal, //普通の状態
    Attaking, //攻撃している状態
    Damageing //ダメージを受けている状態
}
public enum PlayerAnimatioName
{
    Idel,Jump, Forward_Ground_Attack, Forward_Walk,Forward_Dash,Miss_Forward_Dash,
    Forward_Run_Sky, Miss_Forward_Run_Sky, Forward_Sky_Attack,
    Forward_Up_Jump,Forward_Down_Jump
}
public enum EntityTag
{
    Player,Enemy,Ground,Goal
}