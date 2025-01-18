using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameEndPresenter : MonoBehaviour
{
    [SerializeField] private GameEndModel model;
    [SerializeField] private GameEndView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.endGame();
    }
}
