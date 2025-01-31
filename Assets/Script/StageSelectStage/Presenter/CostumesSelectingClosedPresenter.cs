using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CostumesSelectingClosedPresenter : MonoBehaviour
{
    [SerializeField] private CostumeSelectingOptonModel model;
    [SerializeField] private CostsumeSelectingOptionView view;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.closeWindow();
    }
}
