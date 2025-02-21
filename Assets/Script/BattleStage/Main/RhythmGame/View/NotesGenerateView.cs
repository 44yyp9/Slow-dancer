using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NotesGenerateView : MonoBehaviour
{

    private ReactiveProperty<List<float>> _notesData = new ReactiveProperty<List<float>>();
    //presenterÇ©ÇÁPlayerControllerÇ…çwì«Ç≥ÇπÇÈ
    public ReactiveProperty<int> noteOrdered;
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
            float delayTime = notes[i];
            noteOrdered = new ReactiveProperty<int>(i);
            while (delayTime > 0 )
            {
                if (GameTime.playingTime == 0)
                {
                    delayTime += GameTime.playingTime;
                }
                else
                {
                    delayTime -= GameTime.playingTime;
                }
                yield return null;
            }
            yield return new WaitForSeconds(delayTime);
            Vector3 generatePosi=gameObject.transform.position;
            Instantiate(notePrefab, generatePosi, Quaternion.identity,gameObject.transform);
        }
    }
}
