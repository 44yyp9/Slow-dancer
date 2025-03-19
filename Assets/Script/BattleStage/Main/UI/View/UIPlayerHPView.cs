using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UIPlayerHPView : UIView
{
    public ReactiveProperty<bool> isDead=new ReactiveProperty<bool>(false);
    [SerializeField] private Slider HpSlider;
    public override void upPointAnimation()
    {
        
    }
    public override void downPointAnimation()
    {
        
    }
    public void ChangeFillLength(float hp)
    {
        //Dotweenでアニメーションの実装
        HpSlider.value = hp;
    }
}
