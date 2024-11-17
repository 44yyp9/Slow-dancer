using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class NotesHitter : MonoBehaviour
{
    /// <summary>
    /// �ł��߂���note�̒T��
    /// </summary>
    public ReactiveProperty<GameObject> nearNoteObj = new ReactiveProperty<GameObject>();
    private ReactiveProperty<int> _countingPushButton = new ReactiveProperty<int>();
    public ReactiveProperty<int> countingPushButton
    {
        get { return _countingPushButton; }
        set
        {
            if (_countingPushButton.Value != value.Value)
            {
                //�V������ԋ߂��m�[�c�̒T��
                nearNoteObj.Value = findNearNote();
                _countingPushButton.Value = value.Value;
            }
        }
    }
    private GameObject findNearNote()
    {
        GameObject[] allNotesObj = GameObject.FindGameObjectsWithTag("Notes");
        var keyBordPosi=gameObject.transform.position;
        Func<GameObject> isNearNote = () =>
        {
            GameObject nearNote = new GameObject();
            for (int i = 0; allNotesObj.Length > i; i++)
            {
                //�����l�̐ݒ�
                if(i==0) nearNote = allNotesObj[i];
                //�ł��߂��m�[�c�̌v�Z
                var note = allNotesObj[i];
                var notePosi = note.transform.position;
                var _distance = notePosi - keyBordPosi;
                var distance=new Vector2(_distance.x, _distance.y);
                var _minDistance=nearNote.transform.position - keyBordPosi;
                var minDistance = new Vector2(_minDistance.x, _minDistance.y);
                if (distance.sqrMagnitude < minDistance.sqrMagnitude&&note.activeSelf)
                {
                    nearNote = note;
                }
            }
            return nearNote;
        };
        var nearNote = isNearNote();
        return nearNote;
    }
    /// <summary>
    /// �R���{�̒ʒm���s��
    /// </summary>
    private ReactiveProperty<List<hitterType>> _notesHitterList=new ReactiveProperty<List<hitterType>>();
    //�v���p�e�B����肭���΂��Ȃ�
    public ReactiveProperty<List<hitterType>> notesHitterList
    {
        get { return _notesHitterList; }
        set
        {
            if (_notesHitterList.Value != value.Value)
            {
                Debug.Log("test");
                _notesHitterList.Value=value.Value;
            }
        }
    }

    [SerializeField] private Combo combo;
    public enum hitterType
    {
        Good,
        Bad
    }
    public void isGoodHit()
    {
        Debug.Log("hit!");
        combo.comboList.Value.Add(hitterType.Good);
    }
    public void isBadHit()
    {
        Debug.Log("bad!");
        combo.comboList.Value.Add(hitterType.Bad);
    }

    private void Start()
    {
        StartCoroutine(findNotesCoroutine());
    }
    IEnumerator findNotesCoroutine()
    {
        while (true)
        {
            GameObject[] allNotesObj = GameObject.FindGameObjectsWithTag("Notes");
            if (allNotesObj.Length != 0)
            {
                nearNoteObj.Value = findNearNote();
                break;
            }
            yield return null;
        }
    }
}
