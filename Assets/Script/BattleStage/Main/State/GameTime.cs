using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameTime : MonoBehaviour
{
    private float time;
    [SerializeField] private bool isPlaying;
    public static float playingTime;
    [SerializeField] private bool isPause;
    public static float pauseTime;
    private void Start()
    {
        isPlaying = true;
        isPause=false;
    }
    private void Update()
    {
        time = Time.deltaTime;
        //プレイ中ならplayingTimeは0じゃない
        if (isPlaying) playingTime = time;
        else playingTime = 0;
        //ポーズ中ならpauseTimeは0じゃない
        if(isPause) pauseTime = time;
        else pauseTime = 0;
    }
    //以下のメソッドを提供することでplayかpasuseの切り替えを行う
    public void playGame()
    {
        isPlaying=true;
        isPause=false;
    }
    public void pauseGame()
    {
        isPause=true;
        isPlaying=false;
    }
}
