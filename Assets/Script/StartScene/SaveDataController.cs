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
    /// �V�K�ɃQ�[�����n�߂�Ƃ��ɐV�K�f�[�^��auto�̃Z�[�u�f�[�^�ɃR�s�[�A���h�y�[�X�g����
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
        //�ȉ��Ƀf�[�^�̏㏑��
        saveData.OpenedStages = StagesMapModel.opendStage;
        saveData.Coins = PossessionCoin.possessionCoin;
        saveData.PlayerMapPosition=PlayerMapPositionModel.playerMapPositon;
        //saveData.Cosutumes = saveData.Cosutumes; �����̃X�L���I���͕ۗ�
        saveData.StagesScore = StagesScore.stagesScore.StagesScore; //�����̃X�e�[�W�̃X�R�A���ۗ�
        //�㏑�������f�[�^��json�ɏ㏑��
        json = JsonUtility.ToJson(saveData);
        File.WriteAllText (jsonPath, json);
    }
    public void load(string jsonPath)
    {
        jsonPath = conversionSoundJsonPath( jsonPath);
        json=File.ReadAllText(jsonPath);
        data = JsonUtility.FromJson<SaveDataStruct.SaveData>(json);
        //�ȉ��ɃQ�[�����f�[�^�̃V���O���g�����Ăяo��json�t�@�C���̃f�[�^�ɏ㏑��
        StagesMapModel.opendStage=data.OpenedStages;
        PossessionCoin.possessionCoin=data.Coins;
        PlayerMapPositionModel.playerMapPositon=data.PlayerMapPosition;
        StagesScore.stagesScore.StagesScore =data.StagesScore;
        //var i4=data.Cosutumes; �����̃X�L���I���͕ۗ�
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
