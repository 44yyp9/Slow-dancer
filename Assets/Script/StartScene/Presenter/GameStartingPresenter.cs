using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameStartingPresenter : MonoBehaviour
{
    [SerializeField] private GameStartingView view;
    [SerializeField] private GameStartingModel model;
    private void Start()
    {
        view.clicked(onClicked);
    }
    private void onClicked()
    {
        model.startGame();
    }
}
