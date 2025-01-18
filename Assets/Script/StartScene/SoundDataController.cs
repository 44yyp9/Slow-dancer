using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

public class SoundDataController
{
    private string json;
    private string soundJsonPath = "Save/SoundVolume.json";
    private SoundVoulumeStruct.SoundVolumeData soundVolume;
    public void setBGMVolume(float BGMVolume)
    {
        //早期リターンによるガード節
        if (BGMVolume > 1 || BGMVolume < 0) return;
        //ビルド後に対応したパスにするため
        soundJsonPath=conversionSoundJsonPath();
        //サウンドjsonデータの読み込み
        json=File.ReadAllText(soundJsonPath);
        soundVolume = JsonUtility.FromJson<SoundVoulumeStruct.SoundVolumeData>(json);
        //stringのjsonデータを書き換える
        soundVolume.BGMVolume = BGMVolume;
        json=JsonUtility.ToJson(soundVolume);
        //jsonデータを上書き
        File.WriteAllText(soundJsonPath, json);
    }
    public void setSEVolume(float SEVolume)
    {
        //早期リターンによるガード節
        if (SEVolume > 1 || SEVolume < 0) return;
        //ビルド後に対応したパスにするため
        soundJsonPath = conversionSoundJsonPath();
        //サウンドjsonデータの読み込み
        json = File.ReadAllText(soundJsonPath);
        soundVolume = JsonUtility.FromJson<SoundVoulumeStruct.SoundVolumeData>(json);
        //stringのjsonデータを書き換える
        soundVolume.SEVolume = SEVolume;
        json = JsonUtility.ToJson(soundVolume);
        //jsonデータを上書き
        File.WriteAllText(soundJsonPath, json);
    }
    public SoundVoulumeStruct.SoundVolumeData readSoundVolume()
    {
        //ビルド後に対応したパスにするため
        soundJsonPath = conversionSoundJsonPath();
        json = File.ReadAllText(soundJsonPath);
        soundVolume = JsonUtility.FromJson<SoundVoulumeStruct.SoundVolumeData>(json);
        return soundVolume;
    }
    private string conversionSoundJsonPath()
    {
        soundJsonPath= Path.Combine(Application.streamingAssetsPath,soundJsonPath);
        return soundJsonPath;
    }
}