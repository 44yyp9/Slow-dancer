using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace RhythmGameScene
{
    public class NoteHitterModel : MonoBehaviour
    {
        //statticでいけるか
        public static int hitNumber = 0;
        private NoteMovingModel _movingModel;
        [SerializeField] private GameObject KeyBord;
        [SerializeField] private Combo _combo;
        private Collider2D KeyBordCollider;
        //ReactivePropaerでPresenter側でViewを上手く処理する
        public ReactiveProperty<HitterType.hitterType> HitType { get; private set; } = new ReactiveProperty<HitterType.hitterType>();
        public HitterType.hitterType hitType { get;private set; }
        private Action _ignoreNote;
        private string _keyTag;
        private const float GoodLength = 1f;
        private const float MissLength = 10f;
        //被さっているかの確認
        public static bool isOverlaping;
        private void SetMoveingModel()
        {
            _movingModel = new NoteMovingModel();
        }
        private void SetKeyBord()
        {
            _keyTag = KeyBord.tag;
        }
        public void SetAction(Action action)
        {
            _ignoreNote = action;
        }
        public void SetUpModel()
        {
            SetMoveingModel();
            SetKeyBord();
        }
        /// <summary>
        /// keyBordに入ったとき
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(_keyTag))
            {
                KeyBordCollider = collision;
                isOverlaping = true;
            }
        }
        /// <summary>
        /// keyBordから出た時
        /// </summary>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(_keyTag))
            {
                isOverlaping = false;
                _ignoreNote?.Invoke();
                //MisHitはOnExiteがactive falseのときも発火してしまうため要変更が必要
                ThroughNote();
            }
        }
        private void OnDisable()
        {
            isOverlaping = false;
            hitNumber++;
            //発火しているかの確認
            //Debug.Log(hitNumber);
        }
        public void MoveNote()
        {
            _movingModel.Move(gameObject, KeyBord);
        }
        public void JugeHitter()
        {
            try
            {
                var notePosiX = gameObject.transform.position.x;
                var keyBordPosiX = KeyBordCollider.bounds.center.x;
                var length = notePosiX - keyBordPosiX;
                if (-1 * GoodLength < length || length < GoodLength)
                {
                    GoodHit();
                }
                else
                {
                    MissHit();
                }
            }
            catch
            {
                //気休め程度の実装のため後に修正する
            }
        }
        private void ThroughNote()
        {
            var notePosiX = transform.position.x;
            var keyBordBounds = KeyBordCollider.bounds;

            bool isInside = keyBordBounds.min.x <= notePosiX && notePosiX <= keyBordBounds.max.x;

            if (!isInside)
            {
                MissHit();
            }
        }
        private void GoodHit()
        {
            HitType.Value = HitterType.hitterType.Good;
            //newでいけるか分からない
            _combo.comboElement = new HitterType(hitNumber, HitType.Value);
        }
        private void MissHit()
        {
            HitType.Value = HitterType.hitterType.Bad;
            //newでいけるか分からない
            _combo.comboElement = new HitterType(hitNumber, HitType.Value);
        }
    }
}
