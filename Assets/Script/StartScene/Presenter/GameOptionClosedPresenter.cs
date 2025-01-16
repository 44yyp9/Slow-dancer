using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOptionClosedPresenter : MonoBehaviour
{
    [SerializeField] private GameOptionModel model;
    [SerializeField] private GameOptionView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.closeWindow();
    }
}
