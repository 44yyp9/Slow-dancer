using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Options
{
    SoundDataController soundData;
    public static float bgmValue = 0.5f;
    public static float seValue = 0.5f;
    public void setBgmValue(float setValue)
    {
        soundData = new SoundDataController();
        soundData.setBGMVolume(setValue);
        bgmValue = setValue;
    }
    public void setSeValue(float setValue)
    {
        soundData = new SoundDataController();
        soundData.setSEVolume(setValue);
        seValue = setValue;
    }
}
