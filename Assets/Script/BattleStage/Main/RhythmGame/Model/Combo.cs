using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Combo : MonoBehaviour, IComboable
{
    public ReactiveProperty<int> combo;
    public ReactiveProperty<bool> isCombo;
    private List<HitterType> hitList = new List<HitterType>();
    private HitterType _comboElement;
    /// <summary>
    /// notesHitterの変更を検知してコンボの処理を行う
    /// </summary>
    public HitterType comboElement
    {
        get { return _comboElement; }
        set
        {
            _comboElement = value;
            hitList.Add(_comboElement);
            isCombo.Value = BooleanjudgeCombo();
            judageCombo();
        }
    }
    public bool BooleanjudgeCombo()
    {
        var hitingType = hitList[hitList.Count - 1].hitType;
        if (hitingType == HitterType.hitterType.Good) return true;
        else return false;
    }
    private int addCombo()
    {
        combo.Value++;
        return combo.Value;
    }
    private int resetCombo()
    {
        return 0;
    }
    private void judageCombo()
    {
        if (isCombo.Value)
        {
            combo.Value = addCombo();
        }
        else
        {
            combo.Value = resetCombo();
        }
    }
}
