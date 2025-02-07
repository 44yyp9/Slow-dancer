using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultStandingPicturePresenter : MonoBehaviour
{
    [SerializeField] private ResultStandingPictureModel model;
    [SerializeField] private ResultStandingPictureView view;
    private void Start()
    {
        model.sprite.Subscribe(_ => view.standingPicture.Value = model.sprite.Value).AddTo(this);
        model.setStandingPicture();
        view.showStandingPicture();
    }
}
