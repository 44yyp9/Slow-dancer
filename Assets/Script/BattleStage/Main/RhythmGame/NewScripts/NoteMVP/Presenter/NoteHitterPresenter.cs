using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteHitterPresenter : MonoBehaviour
    {
        [SerializeField] public NoteHitterModel _model {  get; private set; }
        [SerializeField] private NoteView _view;
        public void Move()
        {
            _model.MoveNote();
        }
        public void ShowNote()
        {
            _model.SetUpModel();
            _view.Show();
        }
        public void jugeHide()
        {
            _model.JugeHitter();
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
    }
}
