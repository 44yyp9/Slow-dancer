using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIComboModel : MonoBehaviour
{
    public ReactiveProperty<int> combo=new ReactiveProperty<int>(0);
    public ReactiveProperty<bool> isCombo=new ReactiveProperty<bool>(false);
}
