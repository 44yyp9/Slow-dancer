using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameLoadingPresenter : MonoBehaviour
{
    [SerializeField] private GameLoadingView gameLoadingView;
    [SerializeField] private GameLoadingModel gameLoadingModel;
    private void Start()
    {
        gameLoadingView.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        gameLoadingModel.loadGame();
    }

}
