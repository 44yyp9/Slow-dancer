using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Combo : MonoBehaviour
{
    private ReactiveProperty<List<NotesHitter.hitterType>> _comboList =new ReactiveProperty<List<NotesHitter.hitterType>>();
    public ReactiveProperty<List<NotesHitter.hitterType>> comboList
    {
        get { return _comboList; }
        set { _comboList = value; }
    }
}
