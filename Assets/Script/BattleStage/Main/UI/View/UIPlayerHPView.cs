using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIPlayerHPView : UIView
{
    public ReactiveProperty<bool> isDead=new ReactiveProperty<bool>(false);
    public override void upPointAnimation()
    {
        
    }
    public override void downPointAnimation()
    {
        
    }
}
