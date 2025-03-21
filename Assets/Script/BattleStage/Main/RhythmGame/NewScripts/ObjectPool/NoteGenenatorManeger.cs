using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace RhythmGameScene
{
    public class NoteGenenatorManeger : MonoBehaviour
    {
        [SerializeField] private NoteObjectPool Pool;
        private ReadingNote ReadingNotes;
        [SerializeField] private string bgmPath = "";
        private float[] timings;
        private int noteOrder;
        private float ManegerTime;
        public static float NoteSpan = 1.0f;
        private const float noteMagnification = 1.2f;
        [SerializeField] private const float LeftX = -30f;
        [SerializeField] private const float RigthX = 30f;
        private void OnEnable()
        {
            ManegerTime = 0;
            noteOrder = 0;
            Pool.SetUPPool();
            Pool.CreatPool();
            ReadingNotes=new ReadingNote(bgmPath);
            var timingCount = ReadingNotes.GenerateNoteData().Count;
            timings = new float[timingCount];
            timings=ReadingNotes.GenerateNoteData().ToArray();
            SetNoteSpan(timings[0]);
        }
        private void Update()
        {
            if (GameTime.playingTime != 0)
            {
                UpdateRhythmGame();
                SpwnNote();
            }
        }
        private void UpdateRhythmGame()
        {
            Pool.Excute();
        }
        private void SpwnNote()
        {
            ManegerTime += GameTime.playingTime;
            if (timings[noteOrder] < ManegerTime)
            {
                //note‚ð“ñŒÂ¶¬‚·‚é
                Pool.SpwnNote(LeftX);
                Pool.SpwnNote(RigthX);
                noteOrder++;
                //‚±‚±‚Í–{—ˆˆê”Ô–Ú‚Ì‘O‚Ìƒm[ƒc‚Ì•b”‚ðget‚·‚é
                SetNoteSpan(timings[noteOrder]);
                ManegerTime = 0;
            }
        }
        private void SetNoteSpan(float span)
        {
            var prevSpan = (float)NoteSpan / NoteSpan;
            if (prevSpan > span)
            {
                return;
            }
            var _span=span*noteMagnification;
            NoteSpan = _span;
        }
    }
}
