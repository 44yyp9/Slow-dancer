using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class UIComboModel : MonoBehaviour
{
    public ReactiveProperty<int> combo=new ReactiveProperty<int>(0);
    public ReactiveProperty<bool> isCombo=new ReactiveProperty<bool>(false);
    public ReactiveProperty<int> comboEnegy=new ReactiveProperty<int>(0);
    private void AddEnegy()
    {
        var _combo=combo.Value;
        var _nextEnegy=comboEnegy.Value;
        if (EnegyLimits.Length == _nextEnegy)
        {
            return;
        }
        if (EnegyLimits[_nextEnegy] <= _combo)
        {
            _nextEnegy++;
            comboEnegy.Value = _nextEnegy;
        }
    }
    [SerializeField] private int[] EnegyLimits = new int[4]; 
    private void ResetEnegy()
    {
        comboEnegy.Value=0;
    }
    public void ManegeEnegy()
    {
        if (!isCombo.Value)
        {
            ResetEnegy();
            return;
        }
        AddEnegy();
    }
}
