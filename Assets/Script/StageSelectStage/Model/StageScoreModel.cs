using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StageScoreModel : MonoBehaviour
{
    private SaveDataStruct.SaveData.StageScore score;
    private StagesScore stageScore;
    [SerializeField] private PlayerMapPositionModel playerPosition;
    //以下がスコアの描画に用いるインスタンス
    public ReactiveProperty<string> stageCleared = new ReactiveProperty<string>();
    public ReactiveProperty<string> highScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> secondScore = new ReactiveProperty<string>();
    public ReactiveProperty<string> thirdScore = new ReactiveProperty<string>();
    //プレイヤーのMap場所はシングルトンで管理しているためインスタンス化する必要はない
    public void changeScoreText()
    {
        stageScore=new StagesScore();
        //代入した変数のscoreをgetできる
        score = stageScore.getStageScore(PlayerMapPositionModel.playerMapPositon);
        stageCleared.Value = convertCleared(score.IsCleared);
        highScore.Value=score.HighScore.ToString();
        secondScore.Value=score.SecondScore.ToString();
        thirdScore.Value=score.ThirdScore.ToString();
    }
    //クリア確認のテキストを生成するメソッド
    private string convertCleared(bool cleared)
    {
        string text = "default";
        if (cleared)
        {
            text = "クリアしました";
        }
        if (!cleared)
        {
            text = "まだクリアしていません";
        }
        return text;
    }
    private void Start()
    {
        changeScoreText();
        //プレイヤーの位置が変化すると発火するようにする
        playerPosition.ObservablePlayerMapPosition.Subscribe(_ => changeScoreText()).AddTo(this);
    }
    private void debugTest()
    {
        var saveController = new SaveDataController();
        saveController.load("Save/SaveData1.json");
    }
}
