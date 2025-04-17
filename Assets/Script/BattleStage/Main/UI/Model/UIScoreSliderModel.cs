using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UIScoreSliderModel
{
    private Image SliderBaseSprite;
    private Image SliderSpreite;
    private List<Sprite> Sliders;
    private List<int> ScoreRank;
    //ここから上は代入が必要
    private int Score;
    private int Rank;
    public UIScoreSliderModel(Image sliderBaseSprite, Image sliderSpreite, List<Sprite> sliders,List<int> scoreRank)
    {
        Rank = 1;
        //代入が必要
        SliderBaseSprite = sliderBaseSprite;
        SliderSpreite = sliderSpreite;
        Sliders = sliders;
        ScoreRank = scoreRank;
    }
    public float IsSliderValue(int score)
    {
        Score = score;
        var sliderValue = TransLateSliderValue();
        if (sliderValue >= 1&&Rank<=ScoreRank.Count-1)
        {
            Rank++;
            sliderValue=TransLateSliderValue();
        }
        ChangeSprite();
        return sliderValue;
    }
    private float TransLateSliderValue()
    {
        if (Rank >= ScoreRank.Count - 1)
        {
            return 1f; // これ以上スライダーが進まないようにする
        }
        var currentRankScore = ScoreRank[Rank - 1];
        var nextRankScore = ScoreRank[Rank];
        var length = nextRankScore - currentRankScore;
        var nowPosi = Score - currentRankScore;
        var _value = (float)nowPosi / length; // 明示的に float にキャスト
        return _value;
    }
    private void ChangeSprite()
    {
        if (Rank <= Sliders.Count - 1)
        {
            SliderBaseSprite.sprite = Sliders[Rank - 1];
            if (Rank < Sliders.Count) // インデックスオーバー防止
            {
                SliderSpreite.sprite = Sliders[Rank];
            }
        }
    }
}
