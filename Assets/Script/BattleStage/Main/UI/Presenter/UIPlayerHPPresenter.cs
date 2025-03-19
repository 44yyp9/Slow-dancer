using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIPlayerHPPresenter : MonoBehaviour
{
    [SerializeField] private UIPlayerHPView playerHPView;
    [SerializeField] private UIPlayerHPModel playerHPModel;
    private void Start()
    {
        subscribePlayerHP();
        subscribeIsDead();
    }
    private void subscribePlayerHP()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition: () => playerHPView.viewPoint != null && playerHPModel.playerHP != null,
            subscribe: () =>
            {
                playerHPModel.playerHP.Subscribe(_ => playerHPModel.ChangeFill()).AddTo(this);
                playerHPModel.playerHP.Subscribe(_ =>playerHPView.ChangeFillLength(playerHPModel.TranslateHP())).AddTo(this);
                playerHPModel.playerHP.Subscribe(_ => playerHPView.viewPoint = playerHPModel.playerHP).AddTo(this);
            }
            ));
    }
    private void subscribeIsDead()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
        condition: () => playerHPView.isDead != null && playerHPModel.isDead != null,
        subscribe: () =>
        {
            playerHPModel.isDead.Subscribe(_ => playerHPView.isDead = playerHPModel.isDead).AddTo(this);
        }
        ));
    }
}
