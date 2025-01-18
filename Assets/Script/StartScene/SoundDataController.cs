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
        //�������^�[���ɂ��K�[�h��
        if (BGMVolume > 1 || BGMVolume < 0) return;
        //�r���h��ɑΉ������p�X�ɂ��邽��
        soundJsonPath=conversionSoundJsonPath();
        //�T�E���hjson�f�[�^�̓ǂݍ���
        json=File.ReadAllText(soundJsonPath);
        soundVolume = JsonUtility.FromJson<SoundVoulumeStruct.SoundVolumeData>(json);
        //string��json�f�[�^������������
        soundVolume.BGMVolume = BGMVolume;
        json=JsonUtility.ToJson(soundVolume);
        //json�f�[�^���㏑��
        File.WriteAllText(soundJsonPath, json);
    }
    public void setSEVolume(float SEVolume)
    {
        //�������^�[���ɂ��K�[�h��
        if (SEVolume > 1 || SEVolume < 0) return;
        //�r���h��ɑΉ������p�X�ɂ��邽��
        soundJsonPath = conversionSoundJsonPath();
        //�T�E���hjson�f�[�^�̓ǂݍ���
        json = File.ReadAllText(soundJsonPath);
        soundVolume = JsonUtility.FromJson<SoundVoulumeStruct.SoundVolumeData>(json);
        //string��json�f�[�^������������
        soundVolume.SEVolume = SEVolume;
        json = JsonUtility.ToJson(soundVolume);
        //json�f�[�^���㏑��
        File.WriteAllText(soundJsonPath, json);
    }
    public SoundVoulumeStruct.SoundVolumeData readSoundVolume()
    {
        //�r���h��ɑΉ������p�X�ɂ��邽��
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