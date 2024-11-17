using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

public class ReadingNotes : MonoBehaviour
{
    public ReactiveProperty<List<float>> noteTimeList { get;set; }=new ReactiveProperty<List<float>>();
    [SerializeField] private string bgmPath;
    [System.Serializable]
    public struct Note
    {
        public float timing;
    }
    public struct NotesData
    {
        public List<Note> Notes;
    }
    public List<float> GenerateNoteData()
    {
        List<float> notes = new List<float>();
        string json = File.ReadAllText(bgmPath);
        NotesData notesData = JsonUtility.FromJson<NotesData>(json);
        for (int i = 0; i < notesData.Notes.Count; i++)
        {
            var noteTime = notesData.Notes[i].timing;
            notes.Add(noteTime);
        }
        return notes;
    }
    private void Start()
    {
        noteTimeList.Value = GenerateNoteData();
    }
}
