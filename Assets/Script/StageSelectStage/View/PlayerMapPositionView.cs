using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PlayerMapPositionView : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    public ReactiveProperty<Vector3> playerPosition;
    public void moveAnimetion(Vector3 previousPosition,Vector3 presentPosition)
    {
        //�����ɃA�j���[�V�����̎���
    }
    public void setPlayerPosition()
    {
        playerObject.transform.position=playerPosition.Value;
    }
    private Action onRithtArrowKey;
    private Action onLeftArrowKey;
    //�L�[�̌��m���s��
    private void InputChangePosition()
    {
        //�L�[�̓o�^
        Observable.EveryUpdate()
        .Where(_ => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                onRithtArrowKey?.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                onLeftArrowKey?.Invoke();
            }
            setPlayerPosition();
        })
        .AddTo(this);
    }
    //presenter�Ŕ��΂�����悤�̃��\�b�h
    public void registerKeyActions(Action onRithtArrowKey,Action onLeftArrowKey)
    {
        this.onRithtArrowKey = onRithtArrowKey;
        this.onLeftArrowKey = onLeftArrowKey;
    }
    private void Start()
    {
        InputChangePosition();
    }
}
