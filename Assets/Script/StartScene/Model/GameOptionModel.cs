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
        var bgmVoulum=Options.bgmValue;
        var seVoulum=Options.seValue;
        bgm.volume = bgmVoulum;
        se.volume = seVoulum;
    }
}
