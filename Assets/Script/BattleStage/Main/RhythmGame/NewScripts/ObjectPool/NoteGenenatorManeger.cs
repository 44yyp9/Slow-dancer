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
            GoalObject.SetActive(false);
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
                //noteを二個生成する
                Pool.SpwnNote(LeftX);
                Pool.SpwnNote(RigthX);
                noteOrder++;
                //ここは本来一番目の前のノーツの秒数をgetする
                SetNoteSpan(timings[noteOrder]);
                SpwanGoal();
                ManegerTime = 0;
            }
        }
        [SerializeField] private GameObject GoalObject;
        [SerializeField] private GameObject Player;
        //本番の実装のときには変更する
        private void SpwanGoal()
        {
            if(noteOrder> ReadingNotes.GenerateNoteData().Count-2)
            {
                Debug.Log("Spwned");
                var posi = Player.transform.position;
                posi += new Vector3(40f, 20f, 0);
                GoalObject.transform.position = posi;
                GoalObject.AddComponent<Rigidbody2D>();
                GoalObject.AddComponent<BoxCollider2D>();
                GoalObject.tag = EntityTag.Goal.ToString();
                GoalObject.SetActive(true);
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
