using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesGenerateView : MonoBehaviour
{
    public static float delayTime;
    private ReactiveProperty<List<float>> _notesData = new ReactiveProperty<List<float>>();
    public ReactiveProperty<List<float>> notesData
    {
        get { return _notesData; }
        set
        {
            if (value != _notesData)
            {
                _notesData = value;
                StartCoroutine(InstantiateNotes(_notesData.Value));
            }
        }
    }
    [SerializeField] private GameObject notePrefab;
    IEnumerator InstantiateNotes(List<float> notes)
    {
        for(int i = 0; notes.Count > i; i++)
        {
            var _delayTime = notes[i];
            delayTime = _delayTime;
            while (_delayTime > 0 )
            {
                if (GameTime.playingTime == 0)
                {
                    _delayTime += GameTime.playingTime;
                }
                else
                {
                    _delayTime -= GameTime.playingTime;
                }
                yield return null;
            }
            yield return new WaitForSeconds(_delayTime);
            Vector3 generatePosi=gameObject.transform.position;
            Instantiate(notePrefab, generatePosi, Quaternion.identity,gameObject.transform);
        }
    }
}
