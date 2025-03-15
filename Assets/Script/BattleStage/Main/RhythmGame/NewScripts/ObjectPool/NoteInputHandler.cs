using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;
using System;

namespace RhythmGameScene
{
    public class NoteInputHandler
    {
        public void Inputed(Action action,MonoBehaviour used)
        {
            var inputManeger = new InputPlayerManeger();
            ServiceLocator.Register(inputManeger);
            Observable.EveryUpdate().Do(_ => inputManeger.updateInputs()).Where(_ => inputManeger.anyInput()).Subscribe(_ => action()).AddTo(used);
            //Observable.EveryUpdate().Where( _=>Input.GetKeyDown(KeyCode.S)).Subscribe(_ => Debug.Log("every")).AddTo(used);
        }
    }
}
