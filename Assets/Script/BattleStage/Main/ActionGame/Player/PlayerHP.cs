using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHP : MonoBehaviour,IDamegeable
{
    public ReactiveProperty<int> hp;
    public void damege(int damegePoint)
    {
        hp.Value -= damegePoint;
    }
    public void dead()
    {
        //€‚ñ‚¾‚Æ‚«‚Ìˆ—‚ğ‘‚­
    }
}
