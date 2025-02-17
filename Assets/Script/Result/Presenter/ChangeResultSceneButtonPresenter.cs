using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ChangeResultSceneButtonPresenter : MonoBehaviour
{
    [SerializeField] private ChangeResultSceneButtonModel model;
    [SerializeField] private ChangeResultSceneButtonView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.changeScene();
    }

}
