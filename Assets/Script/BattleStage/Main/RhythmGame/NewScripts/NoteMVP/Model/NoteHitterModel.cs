using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace RhythmGameScene
{
    public class NoteHitterModel : MonoBehaviour
    {
        //stattic�ł����邩
        public static int hitNumber = 0;
        private NoteMovingModel _movingModel;
        [SerializeField] private GameObject KeyBord;
        [SerializeField] private Combo _combo;
        private Collider2D KeyBordCollider;
        //ReactivePropaer��Presenter����View����肭��������
        public ReactiveProperty<HitterType.hitterType> HitType { get; private set; } = new ReactiveProperty<HitterType.hitterType>();
        public HitterType.hitterType hitType { get;private set; }
        private Action _ignoreNote;
        private string _keyTag;
        private const float GoodLength = 1f;
        private const float MissLength = 10f;
        //�킳���Ă��邩�̊m�F
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
        /// keyBord�ɓ������Ƃ�
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
        /// keyBord����o����
        /// </summary>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(_keyTag))
            {
                isOverlaping = false;
                _ignoreNote?.Invoke();
                //MisHit��OnExite��active false�̂Ƃ������΂��Ă��܂����ߗv�ύX���K�v
                ThroughNote();
            }
        }
        private void OnDisable()
        {
            isOverlaping = false;
            hitNumber++;
            //���΂��Ă��邩�̊m�F
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
                //�C�x�ߒ��x�̎����̂��ߌ�ɏC������
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
            //new�ł����邩������Ȃ�
            _combo.comboElement = new HitterType(hitNumber, HitType.Value);
        }
        private void MissHit()
        {
            HitType.Value = HitterType.hitterType.Bad;
            //new�ł����邩������Ȃ�
            _combo.comboElement = new HitterType(hitNumber, HitType.Value);
        }
    }
}
