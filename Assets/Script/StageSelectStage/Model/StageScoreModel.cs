using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StageScoreModel : MonoBehaviour
{
    private SaveDataStruct.SaveData.StageScore score;
    private StagesScore stageScore;
    [SerializeField] private PlayerMapPositionModel playerPosition;
    //�ȉ����X�R�A�̕`��ɗp����C���X�^���X
    public ReactiveProperty<string> stageCleared = new ReactiveProperty<string>();
    public ReactiveProperty<string> highScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> secondScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> thirdScore = new ReactiveProperty<string>();
    //�v���C���[��Map�ꏊ�̓V���O���g���ŊǗ����Ă��邽�߃C���X�^���X������K�v�͂Ȃ�
    public void changeScoreText()
    {
        stageScore=new StagesScore();
        //��������ϐ���score��get�ł���
        score = stageScore.getStageScore(PlayerMapPositionModel.playerMapPositon);
        stageCleared.Value = convertCleared(score.IsCleared);
        highScore.Value=score.HighScore.ToString();
        secondScore.Value=score.SecondScore.ToString();
        thirdScore.Value=score.ThirdScore.ToString();
    }
    //�N���A�m�F�̃e�L�X�g�𐶐����郁�\�b�h
    private string convertCleared(bool cleared)
    {
        string text = "default";
        if (cleared)
        {
            text = "�N���A���܂���";
        }
        if (!cleared)
        {
            text = "�܂��N���A���Ă��܂���";
        }
        return text;
    }
    private void Start()
    {
        changeScoreText();
        //�v���C���[�̈ʒu���ω�����Ɣ��΂���悤�ɂ���
        playerPosition.ObservablePlayerMapPosition.Subscribe(_ => changeScoreText()).AddTo(this);
    }
    private void debugTest()
    {
        var saveController = new SaveDataController();
        saveController.load("Save/SaveData1.json");
    }
}
