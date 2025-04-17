using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHPSender : MonoBehaviour
{
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private UIPlayerHPModel playerHPModel;
    [SerializeField] private PlayerAnimationManeger playerAnimationManeger;
    private void Start()
    {
        playerHP.hp.Subscribe(_ =>playerHPModel.playerHP=playerHP.hp).AddTo(this);
        playerHP.hp.Subscribe(_ => playerAnimationManeger.playerHP = playerHP.hp).AddTo(this);
    }
}
