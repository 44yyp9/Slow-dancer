using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIPlayerHPModel : MonoBehaviour
{
    private ReactiveProperty<int> _playerHP=new ReactiveProperty<int>(100);
    public ReactiveProperty<int> playerHP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP.Value <= 0) isDead.Value = true;
        }
    }
    public ReactiveProperty<bool> isDead = new ReactiveProperty<bool>(false);
}
