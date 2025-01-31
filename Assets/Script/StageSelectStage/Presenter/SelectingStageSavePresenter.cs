using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectingStageSavePresenter : MonoBehaviour
{
    [SerializeField] private SelectingStageSaveModel model;
    [SerializeField] private SelectingStageSaveView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.saveGame();
    }
}
