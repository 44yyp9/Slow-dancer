using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerAnimationManeger:AnimationManegerBase
{
    public static bool IsGameClear;
    public Animator playerAnimator;
    public ReactiveProperty<bool> comboing;
    public ReactiveProperty<int> playerHP;
    public ReactiveProperty<PlayerTag> playerTag;
    public Rigidbody2D PlayerRigidbody;
    private static int AirPoint = 0;
    private const int AirLimit = 3;
    public ReactiveProperty<string> entityTag {  get; private set; }=new ReactiveProperty<string>();
    private const float MovingMagnification = 1f;
    public const float RunMagnification = MovingMagnification * 7f;
    public const float MissMagnification = MovingMagnification * 5f;
    public const float WalkMagnification = MovingMagnification * 3f;
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
        //�������^�[���Ńl�X�g������������
        if (entityTag.Value == EntityTag.Goal.ToString())
        {
            IsGameClear = true;
            SceneManager.LoadScene("GameResultScene");
        }
    }
    public void gameOver()
    {
        if (playerHP.Value <= 0)
        {
            IsGameClear = false;
            SceneManager.LoadScene("GameResultScene");
        }
    }
    private void Start()
    {
        playerHP.Value = 100;
        IsGameClear = false;
        //�Q�[���J�n���̃^�O�̐ݒ�
        setTag(PlayerTag.Normal);
        playerTag.Subscribe(_ =>HandleDamege()).AddTo(this);
        entityTag.Subscribe(_ =>gameClear()).AddTo(this);
        playerHP.Subscribe(_ =>gameOver()).AddTo(this);
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        SetJumpTag(EntityTag.Air);
        entityTag.Subscribe(_ =>HadleGravity()).AddTo(this);
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
    private void HadleGravity()
    {
        if (entityTag.Value == EntityTag.Air.ToString())
        {
            ForceGravity();
        }
        if (entityTag.Value != EntityTag.Air.ToString())
        {
            FloatgGravity();
        }
        if (entityTag.Value == EntityTag.Ground.ToString())
        {
            AirPoint = 0;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetCollderTag(collision);
    }
    private void SetCollderTag(Collision2D collider)
    {
        var col = collider.gameObject;
        Debug.Log(col.tag.ToString());
        entityTag.Value = col.tag;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == EntityTag.Ground.ToString())
        {
            entityTag.Value = EntityTag.Air.ToString();
        }
    }
    public void SetJumpTag(EntityTag tag)
    {
        entityTag.Value =tag.ToString();
    }
    public void SetAirAnimation()
    {
        AirPoint++;
    }
    public bool IsNextAir()
    {
        var isNext = true;
        if (AirPoint >= AirLimit)
        {
            isNext = false;
        }
        return isNext;
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
    Idel,Jump, Forward_Ground_Attack, Forward_Walk,Forward_Dash,Miss_Forward_Dash,
    Forward_Run_Sky, Miss_Forward_Run_Sky, Forward_Sky_Attack,
    Forward_Up_Jump,Forward_Down_Jump,DownJump
}
public enum EntityTag
{
    Player,Enemy,Ground,Goal,Air,MidAir
}