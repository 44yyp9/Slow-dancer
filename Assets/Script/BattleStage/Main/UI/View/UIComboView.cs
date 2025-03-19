using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.Burst.Intrinsics;

public class UIComboView : UIView
{
    public ReactiveProperty<bool> isCombo=new ReactiveProperty<bool>(false);
    public override void upPointAnimation()
    {
        
    }
    public override void downPointAnimation()
    {
        
    }
    //EnegyObjectをEditor上でセット
    [SerializeField] private GameObject[] Enegys= new GameObject[5];
    public void ShowEnegy(int enegy)
    {
        HideEnegy();
        Enegys[enegy].SetActive(true);
        //ここに簡単なDotweenでアニメーション
    }
    private void HideEnegy()
    {
        foreach (var enemy in Enegys)
        {
            enemy.SetActive(false);
        }
    }
}
