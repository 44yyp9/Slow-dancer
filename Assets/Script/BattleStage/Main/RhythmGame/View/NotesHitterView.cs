using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using static HitterType;

public class NotesHitterView : MonoBehaviour,IJudgmentHitable
{
    //�A�j���[�V�������͂ł��p���邽��static�ϐ���p����
    // �m�[�c���d�Ȃ��Ă��邩�̃t���O
    public static bool isOverlaping;
    //���͂����������̃t���O
    private bool isPushing;
    //��ԋ߂��m�[�c�̌��m
    public ReactiveProperty<GameObject> nearNote { get;  set; }=new ReactiveProperty<GameObject>();
    //���͂��ꂽ���ǂ����̌��m
    public ReactiveProperty<int> countingPushButton { get; set; } = new ReactiveProperty<int>(0);
    //���͂��ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    private void pushNote()
    {
        if (isOverlaping) hit();
        else miss();
    }
    /// <summary>
    /// �m�[�c�̏d�Ȃ�ɂ��Ă̏���
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Notes"))
        {
            isOverlaping = true;
            isPushing = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Notes"))
        {
            isOverlaping = false;
            if (isPushing) return;
            miss();
        }
    }
    /// <summary>
    /// hit�Ƃ����łȂ�miss�̂Ƃ��̏���
    /// </summary>
    public ReactiveProperty<HitterType> catchingHited = new ReactiveProperty<HitterType>(new HitterType(0,hitterType.empty));
    private int hitedOrdering = 0;
    public void miss()
    {
        isPushing = false;
        catchingHited.Value =new HitterType(hitedOrdering,HitterType.hitterType.Bad);
        hitedOrdering++;
        countingPushButton.Value++;
        nearNote.Value.SetActive(false);
    }
    public void hit()
    {
        isPushing= true;
        catchingHited.Value = new HitterType(hitedOrdering, HitterType.hitterType.Good);
        hitedOrdering++;
        countingPushButton.Value++;
        nearNote.Value.SetActive(false);
    }
    private void Start()
    {
        /*
        var inputManeger = new InputPlayerManeger();
        ServiceLocator.Register(inputManeger);
        Observable.EveryUpdate().Do(_ =>inputManeger.updateInputs()).Where(_ => inputManeger.anyInput()).Subscribe(_ => pushNote()).AddTo(this);
        */
    }
}
