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
}
