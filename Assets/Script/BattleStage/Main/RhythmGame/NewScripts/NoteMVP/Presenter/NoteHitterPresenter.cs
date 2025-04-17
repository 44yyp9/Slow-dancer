using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteHitterPresenter : MonoBehaviour
    {
        [SerializeField] public NoteHitterModel _model;
        [SerializeField] private NoteView _view;
        public void Move()
        {
            _model.MoveNote();
        }
        public void ShowNote()
        {
            _model.SetUpModel();
            _model.SetAction(_view.BadHide);
            _view.Show();
        }
        public void jugeHide()
        {
            var _hitType = _model.HitType.Value;
            if (_hitType == HitterType.hitterType.Good)
            {
                _view.GoodHide();
            }
            if (_hitType == HitterType.hitterType.Bad)
            {
                _view.BadHide();
            }
        }
        public void SendCombo()
        {
            _model.JugeHitter();
        }
    }
}
