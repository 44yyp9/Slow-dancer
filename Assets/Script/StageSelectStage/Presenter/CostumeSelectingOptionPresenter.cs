using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CostumeSelectingOptionPresenter : MonoBehaviour
{
    [SerializeField] private CostsumeSelectingOptionView view;
    [SerializeField] private CostumeSelectingOptonModel model;
    private void Start()
    {
        view.clicked(onButtonClicked);
    }
    private void onButtonClicked()
    {
        model.openWindow();
    }
}
