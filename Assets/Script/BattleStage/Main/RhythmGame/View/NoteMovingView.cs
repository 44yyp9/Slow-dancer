using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NoteMovingView : MonoBehaviour
{
    public ReactiveProperty<Transform> notePosition { get;  set; }
    [SerializeField] private float speed;
    private void move(GameObject movingObj)
    {
        var _speed=-speed;
        movingObj.transform.position += new Vector3(_speed, 0, 0) * GameTime.playingTime;
    }
    private void Update()
    {
        move(gameObject);
    }

}
