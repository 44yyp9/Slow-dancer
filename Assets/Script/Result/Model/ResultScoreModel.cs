using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultScoreModel : MonoBehaviour
{
    public ReactiveProperty<string> score = new ReactiveProperty<string>();
    public ReactiveProperty<string> rank= new ReactiveProperty<string>();
    [Header("ランキングのポイントを編集出来るエディタ")]
    [SerializeField] private int[] rankList=new int[5];
    private ResultedRank resultedRank;
    public void setResult()
    {
        resultedRank = getRank(UIScoreModel._score);
        score.Value = getScore();
        rank.Value=resultedRank.ToString();
    }
    public ResultedRank getRank(int scorePoint)
    {
        var _rank = ResultedRank.E;
        //正規表現したいかも
        if (scorePoint >= rankList[0]) _rank = ResultedRank.D;
        if (scorePoint >= rankList[1]) _rank = ResultedRank.C;
        if (scorePoint >= rankList[2]) _rank = ResultedRank.B;
        if (scorePoint >= rankList[3]) _rank = ResultedRank.A;
        if (scorePoint >= rankList[4]) _rank = ResultedRank.S;
        return _rank;
    }
    private string getScore()
    {
        int scorePoint = UIScoreModel._score;
        return scorePoint.ToString();
    }
}

public enum ResultedRank
{
    //ランキング一覧
    S,A,B,C,D,E
}
