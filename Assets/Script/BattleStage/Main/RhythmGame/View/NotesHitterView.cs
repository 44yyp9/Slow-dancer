using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesHitterView : MonoBehaviour,IJudgmentHitable
{
    // ノーツが重なっているかのフラグ
    private bool isOverlaping;
    //入力が入ったかのフラグ
    private bool isPushing;
    //一番近いノーツの検知
    public ReactiveProperty<GameObject> nearNote { get;  set; }=new ReactiveProperty<GameObject>();
    //入力されたかどうかの検知
    public ReactiveProperty<int> countingPushButton { get; set; } = new ReactiveProperty<int>(0);
    //入力されたときに呼び出されるメソッド
    private void pushNote()
    {
        if (isOverlaping) hit();
        else miss();
    }
    /// <summary>
    /// ノーツの重なりについての処理
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
    /// hitとそうでないmissのときの処理
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
