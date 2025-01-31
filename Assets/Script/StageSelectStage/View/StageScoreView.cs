using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class StageScoreView : MonoBehaviour
{
    public ReactiveProperty<string> stageCleared = new ReactiveProperty<string>();
    public ReactiveProperty<string> highScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> secondScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> thirdScore = new ReactiveProperty<string>();
    [SerializeField] private Text stageCleaedText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text secondScoreText;
    [SerializeField] private Text thirdScoreText;
    public void desplayScore()
    {
        stageCleaedText.text=stageCleared.Value;
        highScoreText.text = highScore.Value;
        secondScoreText.text = secondScore.Value;
        thirdScoreText.text = thirdScore.Value;
        changeScoreAnimation();
    }
    private void changeScoreAnimation()
    {
        //スコアを表示したときのアニメーションの処理を書く
    }
    private void Start()
    {
        thirdScore.Subscribe(_ =>desplayScore()).AddTo(this);
    }
}
