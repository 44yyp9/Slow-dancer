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
    //EnegyObject��Editor��ŃZ�b�g
    [SerializeField] private GameObject[] Enegys= new GameObject[5];
    public void ShowEnegy(int enegy)
    {
        HideEnegy();
        Enegys[enegy].SetActive(true);
        //�����ɊȒP��Dotween�ŃA�j���[�V����
    }
    private void HideEnegy()
    {
        foreach (var enemy in Enegys)
        {
            enemy.SetActive(false);
        }
    }
}
