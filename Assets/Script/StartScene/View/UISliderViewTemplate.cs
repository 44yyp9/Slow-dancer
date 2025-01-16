using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public abstract class UISliderViewTemplate : MonoBehaviour
{
    public Slider slider;
    public abstract void onChangedValue(float sliderVaule);
}
