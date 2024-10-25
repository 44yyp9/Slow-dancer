using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MapPresenter : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerModel;
    [SerializeField] private Map mapCurrentPosition;
    [SerializeField] private ViewingPlayer playerView;
    private void Start()
    {
        playerModel.currentStage.Subscribe(_ => playerView.playerPosi = transformPosition(playerModel.currentStage)).AddTo(this);
    }
    private ReactiveProperty<Transform> transformPosition(ReactiveProperty<int> currentPosi)
    {
        var stagesList = mapCurrentPosition.stages;
        var currentStage = stagesList[currentPosi.Value];
        ReactiveProperty<Transform> currentTransform =new ReactiveProperty < Transform > (currentStage.transform);
        return currentTransform;
    }
    public void onForwardKey()
    {
        playerModel.addStage();
    }
    public void onBackKey()
    {
        playerModel.backStage();
    }
}
