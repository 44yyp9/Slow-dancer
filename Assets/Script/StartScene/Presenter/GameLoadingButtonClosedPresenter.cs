using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameLoadingButtonClosedPresenter : MonoBehaviour
{
    [SerializeField] private GameLoadingButtonModel model;
    [SerializeField] private GameLoadingButtonView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.closeWindow();
    }
}
