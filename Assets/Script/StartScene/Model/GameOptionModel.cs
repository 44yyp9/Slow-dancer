using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOptionModel : MonoBehaviour,ISabWindowControllerable
{
    [SerializeField] private GameObject options;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource se;
    public void openWindow()
    {
        options.SetActive(true);
    }
    public void closeWindow()
    {
        options?.SetActive(false);
    }
    private void Start()
    {
        setUpVolume();
    }
    private void setUpVolume()
    {
        var soundDataController=new SoundDataController();
        SoundVoulumeStruct.SoundVolumeData volumeData = soundDataController.readSoundVolume();
        var bgmVoulum=volumeData.BGMVolume;
        var seVoulum=volumeData.SEVolume;
        //volume��BGM�̒l�̏����ݒ�
        bgm.volume = bgmVoulum;
        se.volume = seVoulum;
        //�V���O���g���ɃA�N�Z�X
        Options.bgmValue = bgmVoulum;
        Options.seValue = seVoulum;
    }
}
