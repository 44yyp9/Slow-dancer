using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IDamegeable
{
    public void damege(int damegePoint);
    public void dead();
}
