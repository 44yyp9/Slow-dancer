using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesHitterView : MonoBehaviour,IJudgmentHitable
{
    // �m�[�c���d�Ȃ��Ă��邩�̃t���O
    private bool isOverlaping;
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
    public ReactiveProperty<List<NotesHitter.hitterType>> catchingHiting = new ReactiveProperty<List<NotesHitter.hitterType>>();
    public void miss()
    {
        isPushing = false;
        catchingHiting.Value.Add(NotesHitter.hitterType.Bad);
        countingPushButton.Value++;
        nearNote.Value.SetActive(false);
    }
    public void hit()
    {
        isPushing= true;
        catchingHiting.Value.Add(NotesHitter.hitterType.Good);
        countingPushButton.Value++;
        nearNote.Value.SetActive(false);
    }
    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Space)).Subscribe(_ => pushNote()).AddTo(this);
    }
}
