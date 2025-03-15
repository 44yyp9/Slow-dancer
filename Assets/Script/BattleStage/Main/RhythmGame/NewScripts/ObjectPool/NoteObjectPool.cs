using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RhythmGameScene
{
    public class NoteObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject NotePrefab;
        [SerializeField] private GameObject KeyBordPosi;
        [SerializeField] private Transform ParentObj;
        private struct NoteComponent
        {
            public GameObject NoteObj;
            public NoteHitterPresenter NoteHitter;
        }
        private NoteComponent[] NotePrefabs;
        private const int NoteComponentCount = 20;
        private NoteInputHandler InputHandler;
        public void CreatPool()
        {
            NotePrefabs = new NoteComponent[NoteComponentCount];
            for (int i = 0; i < NotePrefabs.Length; i++)
            {
                NotePrefabs[i].NoteObj=Instantiate(NotePrefab);
                NotePrefabs[i].NoteHitter = NotePrefabs[i].NoteObj.GetComponent<NoteHitterPresenter>();
                NotePrefabs[i].NoteObj.transform.SetParent(ParentObj);
                NotePrefabs[i].NoteObj.SetActive(false);
            } 
        }
        public void SpwnNote(float length)
        {
            for(int i = 0; i < NotePrefabs.Length; i++)
            {
                if (!NotePrefabs[i].NoteObj.activeInHierarchy)
                {
                    NotePrefabs[i].NoteObj.SetActive(true);
                    var posi=KeyBordPosi.transform.position;
                    posi.x += length;
                    NotePrefabs[i].NoteObj.transform.position = posi;
                    NotePrefabs[i].NoteHitter.ShowNote();
                    break;
                }
            }
        }
        public void RealseNote()
        {
            List<NoteComponent> Notes = new List<NoteComponent>();
            var keyBordPosiX = KeyBordPosi.transform.position.x;
            //NotePrefabs[i].NoteObj.transform.position.xを取得し
            //keyBordPosiXとの差が小さい順にNotesをソートする
            foreach(var notePrefab in NotePrefabs)
            {
                Notes.Add(notePrefab);
            }
            Notes.Sort((a, b) =>
                Mathf.Abs(a.NoteObj.transform.position.x - keyBordPosiX)
                .CompareTo(Mathf.Abs(b.NoteObj.transform.position.x - keyBordPosiX)));
            void realse()
            {
                for (int i = 0; i < Notes.Count; i++)
                {
                    if (Notes[i].NoteObj.activeInHierarchy)
                    {
                        Notes[i].NoteHitter.jugeHide();
                        Notes.RemoveAt(i);  // インデックスで削除
                        break;
                    }
                }
            }
            realse();
            realse();
        }
        public void AllRealseNotes()
        {
            for(int i = 0; i < NotePrefabs.Length; i++)
            {
                NotePrefabs[i].NoteObj.SetActive(false);
            }
        }
        public void SetUPPool()
        {
            NoteHitterModel.hitNumber = 0;
            InputHandler = new NoteInputHandler();
            InputHandler.Input(RealseNote,this);
        }
        public void Excute()
        {
            foreach (var note in NotePrefabs)
            {
                if (note.NoteObj.activeInHierarchy)
                {
                    note.NoteHitter.Move();
                }
            }
        }
    }
}
