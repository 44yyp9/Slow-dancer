using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameLoadingModel : MonoBehaviour
{
    [SerializeField] private string saveDataPath;
    public void loadGame()
    {
        Debug.Log("test");
        var savedata=new SaveDataController();
    }
    private void loadSaveData()
    {

    }
    private void goToMap()
    {

    }
}
