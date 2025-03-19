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
    //���������͑�����K�v
    private int Score;
    private int Rank;
    public UIScoreSliderModel(Image sliderBaseSprite, Image sliderSpreite, List<Sprite> sliders,List<int> scoreRank)
    {
        Rank = 1;
        //������K�v
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
            return 1f; // ����ȏ�X���C�_�[���i�܂Ȃ��悤�ɂ���
        }
        var currentRankScore = ScoreRank[Rank - 1];
        var nextRankScore = ScoreRank[Rank];
        var length = nextRankScore - currentRankScore;
        var nowPosi = Score - currentRankScore;
        var _value = (float)nowPosi / length; // �����I�� float �ɃL���X�g
        return _value;
    }
    private void ChangeSprite()
    {
        if (Rank <= Sliders.Count - 1)
        {
            SliderBaseSprite.sprite = Sliders[Rank - 1];
            if (Rank < Sliders.Count) // �C���f�b�N�X�I�[�o�[�h�~
            {
                SliderSpreite.sprite = Sliders[Rank];
            }
        }
    }
}
