using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IJudgmentHitable
{
    public void hit();
    public void miss();
}
