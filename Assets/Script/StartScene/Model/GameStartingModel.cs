using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameStartingModel : MonoBehaviour
{
    [Header("�I�[�g�Z�[�u�̃p�X")]
    [SerializeField] private string autoJsonPath;
    [Header("�n�܂�̃X�g�[���[��Scene�������")]
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
        //�V�K�Z�[�u�f�[�^�̍쐬
        saveDataController.create(autoJsonPath);
        //�V�K�f�[�^����Q�[�����f�[�^�ɔ��f
        saveDataController.load(autoJsonPath);
        Debug.Log(PlayerMapPositionModel.playerMapPositon);
    }
    private void goToMovie()
    {
        SceneManager.LoadScene(startStoryScene);
    }
}
