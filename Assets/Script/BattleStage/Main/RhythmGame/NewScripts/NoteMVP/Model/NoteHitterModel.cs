using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteHitterModel : MonoBehaviour
    {
        //statticでいけるか
        public static int hitNumber = 0;
        private NoteMovingModel _movingModel;
        [SerializeField] private GameObject KeyBord;
        [SerializeField] private Combo _combo;
        //ReactivePropaerでPresenter側でViewを上手く処理する
        public ReactiveProperty<HitterType.hitterType> HitType { get; private set; } = new ReactiveProperty<HitterType.hitterType>();
        public HitterType.hitterType hitType { get;private set; }
        private string _keyTag;
        private const float GoodLength = 5f;
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
            }
        }
        private void OnDisable()
        {
            isOverlaping = false;
            hitNumber++;
            //発火しているかの確認
            Debug.Log(hitNumber);
        }
        public void MoveNote()
        {
            _movingModel.Move(gameObject, KeyBord);
        }
        public void JugeHitter()
        {
            var notePosiX = gameObject.transform.position.x;
            var keyBordPosiX=KeyBord.transform.position.x;
            var length=notePosiX - keyBordPosiX;
            if (-1*GoodLength<length||length<GoodLength)
            {
                GoodHit();
            }
            else
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
