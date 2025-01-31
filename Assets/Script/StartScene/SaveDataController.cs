using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

public class SaveDataController
{
    private string json;
    private SaveDataStruct.SaveData data;
    private string startingSaveDataPath = "Save/StartSaveData.json";
    /// <summary>
    /// 新規にゲームを始めるときに新規データをautoのセーブデータにコピーアンドペーストする
    /// </summary>
    public void create(string jsonPath)
    {
        jsonPath=conversionSoundJsonPath(jsonPath);
        var autoDataPath = "Save/AutoSaveData.json";
        autoDataPath=conversionSoundJsonPath(autoDataPath);
        json = File.ReadAllText(autoDataPath);
        data=JsonUtility.FromJson<SaveDataStruct.SaveData>(json);
        startingSaveDataPath = conversionSoundJsonPath(startingSaveDataPath);
        var startJson=File.ReadAllText(startingSaveDataPath);
        var startData = JsonUtility.FromJson<SaveDataStruct.SaveData>(startJson);
        json=JsonUtility.ToJson(startData);
        File.WriteAllText(jsonPath, json);
    }
    public void save(string jsonPath)
    {
        jsonPath = conversionSoundJsonPath(jsonPath);
        json = File.ReadAllText(jsonPath);
        var saveData=JsonUtility.FromJson<SaveDataStruct.SaveData>(json);
        //以下にデータの上書き
        saveData.OpenedStages = StagesMapModel.opendStage;
        saveData.Coins = PossessionCoin.possessionCoin;
        saveData.PlayerMapPosition=PlayerMapPositionModel.playerMapPositon;
        //saveData.Cosutumes = saveData.Cosutumes; ここのスキン選択は保留
        saveData.StagesScore = StagesScore.stagesScore.StagesScore; //ここのステージのスコアも保留
        //上書きしたデータをjsonに上書き
        json = JsonUtility.ToJson(saveData);
        File.WriteAllText (jsonPath, json);
    }
    public void load(string jsonPath)
    {
        jsonPath = conversionSoundJsonPath( jsonPath);
        json=File.ReadAllText(jsonPath);
        data = JsonUtility.FromJson<SaveDataStruct.SaveData>(json);
        //以下にゲーム内データのシングルトンを呼び出しjsonファイルのデータに上書き
        StagesMapModel.opendStage=data.OpenedStages;
        PossessionCoin.possessionCoin=data.Coins;
        PlayerMapPositionModel.playerMapPositon=data.PlayerMapPosition;
        StagesScore.stagesScore.StagesScore =data.StagesScore;
        //var i4=data.Cosutumes; ここのスキン選択は保留
    }
    public string debugTest(string jsonPath)
    {
        return json;
    }
    private string conversionSoundJsonPath(string jsonPath)
    {
        jsonPath = Path.Combine(Application.streamingAssetsPath, jsonPath);
        return jsonPath;
    }

}
