using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using UnityEngine.UI;

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
    [SerializeField] private Image FillSprite;
    //Fillsの要素数の1少ない
    [SerializeField] private int[] HpFillLimits;
    [SerializeField] private List<Sprite> Fills = new List<Sprite>();
    public float TranslateHP()
    {
        var _hp=(float)_playerHP.Value;
        _hp *= 0.01f; //百分率にする
        return _hp;
    }
    public void ChangeFill()
    {
        var _hp=_playerHP.Value;
        var FillPosi = 0;
        for(var i = 0; i < HpFillLimits.Length; i++)
        {
            if (_hp <= HpFillLimits[i])
            {
                FillPosi = i;
            }
        }
        //Fillオブジェクトのセット
        FillSprite.sprite=Fills[FillPosi];
    }
}
