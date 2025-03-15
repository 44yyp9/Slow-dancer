using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using static HitterType;

public class NotesHitterView : MonoBehaviour,IJudgmentHitable
{
    //アニメーション入力でも用いるためstatic変数を用いる
    // ノーツが重なっているかのフラグ
    public static bool isOverlaping;
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
