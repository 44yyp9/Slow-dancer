using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMapPosionPresenter : MonoBehaviour
{
    [SerializeField] private PlayerMapPositionModel model;
    [SerializeField] private PlayerMapPositionView view;
    public void Start()
    {
        //Žn‚ß‚Ì‰ŠúˆÊ’u‚Ì’è‹`
        model.movePlayerVector();
        model.playerVectorPosition.Subscribe(_ => view.playerPosition = model.playerVectorPosition).AddTo(this);
        view.setPlayerPosition();
        assignKey();
    }
    private void assignKey()
    {
        view.registerKeyActions(
            onRithtArrowKey: model.forwardStage,
            onLeftArrowKey: model.backStage
        );
    }
}
