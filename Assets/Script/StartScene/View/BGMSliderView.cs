using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class BGMSliderView : UISliderViewTemplate
{
    [SerializeField] private AudioSource bgm;
    private void Start()
    {
        bgm.volume = Options.bgmValue;
        slider.value = Options.bgmValue;
        slider.onValueChanged.AddListener(onChangedValue);
    }
    public override void onChangedValue(float vaule)
    {
        var options=new Options();
        options.setBgmValue(vaule);
        bgm.volume = vaule;
    }
}
