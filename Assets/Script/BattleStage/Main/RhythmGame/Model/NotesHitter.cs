using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;
using static HitterType;

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
    private ReactiveProperty<HitterType> _noteHitter = new ReactiveProperty<HitterType>();
    //�v���p�e�B����肭���΂��Ȃ�
    public ReactiveProperty<HitterType> noteHitter
    {
        get { return _noteHitter; }
        set
        {
            _noteHitter.Value = value.Value;
            if (_noteHitter.Value.hitType == HitterType.hitterType.Good) isGoodHit();
            else if (_noteHitter.Value.hitType == HitterType.hitterType.Bad) isBadHit();
            else
            {
                Debug.Log("error hit");
            }
        }
    }

    [SerializeField] private Combo combo;
    public void isGoodHit()
    {
        combo.comboElement = noteHitter.Value;
    }
    public void isBadHit()
    {
        combo.comboElement = noteHitter.Value;
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
public class HitterType
{
    public enum hitterType
    {
        Good,
        Bad,
        empty
    }
    public hitterType hitType { get;set; }
    public int hitOrdering { get; set; }
    public HitterType(int _hitOrdering,hitterType _hitType)
    {
        hitOrdering = _hitOrdering;
        hitType = _hitType;
    }
}
