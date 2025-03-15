using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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
                ManegerTime = 0;
            }
        }
    }
}
