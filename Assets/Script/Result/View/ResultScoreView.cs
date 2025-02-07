using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ResultScoreView : MonoBehaviour
{
    public ReactiveProperty<string> score;
    public ReactiveProperty<string> rank;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text rankText;
    public void showResult()
    {
        scoreText.text = score.Value;
        rankText.text = rank.Value;
    }
}
