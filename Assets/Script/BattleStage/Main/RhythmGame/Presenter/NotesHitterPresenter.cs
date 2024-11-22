using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesHitterPresenter : MonoBehaviour
{
    [SerializeField] private NotesHitter notesHitter;
    [SerializeField] private NotesHitterView notesHitterView;
    private void Start()
    {
        notesHitter.nearNoteObj.Subscribe(_ => notesHitterView.nearNote = notesHitter.nearNoteObj).AddTo(this);
        notesHitterView.catchingHited.Subscribe(_ => notesHitter.noteHitter = notesHitterView.catchingHited ).AddTo(this);
        notesHitterView.countingPushButton.Subscribe( _ =>notesHitter.countingPushButton =notesHitterView.countingPushButton).AddTo(this);
    }
}
