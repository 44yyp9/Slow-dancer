using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHP : MonoBehaviour,IDamegeable
{
    public ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    public void damege(int damegePoint)
    {
        hp.Value -= damegePoint;
    }
    public void dead()
    {
        //€‚ñ‚¾‚Æ‚«‚Ìˆ—‚ğ‘‚­
    }
    private void Start()
    {
        hp.Value = 100;
    }
}
