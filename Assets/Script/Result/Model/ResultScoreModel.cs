using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultScoreModel : MonoBehaviour
{
    public ReactiveProperty<string> score = new ReactiveProperty<string>();
    public ReactiveProperty<string> rank= new ReactiveProperty<string>();
    private ResultedRank resultedRank;
    void setResult()
    {

    }
    private ResultedRank getRank(int scorePoint)
    {
        switch (scorePoint)
        {
            case > 100:
        }
    }
    private string getScore()
    {
        int scorePoint = UIScoreModel._score;
        return scorePoint.ToString();
    }
}

public enum ResultedRank
{
    //ƒ‰ƒ“ƒLƒ“ƒOˆê——
    S,A,B,C,D,E
}
