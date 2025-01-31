using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameStartingModel : MonoBehaviour
{
    [Header("オートセーブのパス")]
    [SerializeField] private string autoJsonPath;
    [Header("始まりのストーリーのScene名を入力")]
    [SerializeField] private string startStoryScene;
    SaveDataController saveDataController;
    public void startGame()
    {
        createSaveData();
        goToMovie();
    }
    private void createSaveData()
    {
        saveDataController = new SaveDataController();
        //新規セーブデータの作成
        saveDataController.create(autoJsonPath);
        //新規データからゲーム内データに反映
        saveDataController.load(autoJsonPath);
        Debug.Log(PlayerMapPositionModel.playerMapPositon);
    }
    private void goToMovie()
    {
        SceneManager.LoadScene(startStoryScene);
    }
}
