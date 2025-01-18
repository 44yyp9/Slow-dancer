using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SESliderView : UISliderViewTemplate
{
    [SerializeField] private AudioSource se;
    private void Start()
    {
        se.volume = Options.seValue;
        slider.value=Options.seValue;
        slider.onValueChanged.AddListener(onChangedValue);
    }
    public override void onChangedValue(float vaule)
    {
        var option = new Options();
        option.setSeValue(vaule);
        se.volume = vaule;
    }
}