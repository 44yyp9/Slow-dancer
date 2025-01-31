using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StagesScore
{
    public static SaveDataStruct.SaveData stagesScore;
    public SaveDataStruct.SaveData.StageScore getStageScore(int stageNumber)
    {
        var score = stagesScore.StagesScore[stageNumber];
        return score;
    }
    public void setScore(int stagNumber,int scoreResulted)
    {
        var stageScore = stagesScore.StagesScore[stagNumber];
        //������score�̗v�f���ɉ����ĉ����邽�ߒ���
        var hightScore = stageScore.HighScore;
        var secondScore=stageScore.SecondScore;
        var thirdScore=stageScore.ThirdScore;
        List<int> scores = new List<int>() { hightScore, secondScore, thirdScore };
        //���݂܂ł̃X�R�A�Ƒ�������X�R�A�̔�r
        for(int i = 0; i < scores.Count; i++)
        {
            if(scores[i] < scoreResulted)
            {
                //�X�R�A�̍����ւ�
                scores[i]= scoreResulted;
                break;
            }
        }
        stageScore.HighScore = scores[0];
        stageScore.SecondScore = scores[1];
        stageScore.ThirdScore = scores[2];
        //�Ō�ɃV���O���g���ɑ��
        stagesScore.StagesScore[stagNumber]=stageScore;
    }
    public void setStageCleared(int stageNumber)
    {
        var score = stagesScore.StagesScore[stageNumber];
        score.IsCleared = true;
        stagesScore.StagesScore[stageNumber] = score;
    }
    public string debugStageScoreText(int stagNumber)
    {
        var stageScore = stagesScore.StagesScore[stagNumber];
        //������score�̗v�f���ɉ����ĉ����邽�ߒ���
        var hightScore = stageScore.HighScore;
        var secondScore = stageScore.SecondScore;
        var thirdScore = stageScore.ThirdScore;
        List<int> scores = new List<int>() { hightScore, secondScore, thirdScore };
        string scoresText = "";
        for(int i = 0; i < scores.Count; i++)
        {
            scoresText += ","+ scores[i].ToString();
        }
        return scoresText;
    }
}