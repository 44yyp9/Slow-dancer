using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesGeneratePresenter : MonoBehaviour
{
    [SerializeField] private ReadingNotes readingNotes;
    [SerializeField] private NotesGenerateView notesGenerateView;
    private void Start()
    {
        readingNotes.noteTimeList.Subscribe(_ => notesGenerateView.notesData = readingNotes.noteTimeList).AddTo(this);
    }
}
