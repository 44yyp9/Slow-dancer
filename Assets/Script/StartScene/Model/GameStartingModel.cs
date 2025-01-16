using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameStartingModel : MonoBehaviour
{
    SaveDataController saveDataController;
    public void startGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene("StartScene");
    }
    private void createSaveData()
    {

    }
    private void goToMovie()
    {

    }
}
