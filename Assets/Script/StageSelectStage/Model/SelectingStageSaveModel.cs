using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectingStageSaveModel : MonoBehaviour
{
    private SaveDataController saveDataController;
    [SerializeField] string saveDataPath;
    public void saveGame()
    {
        saveDataController = new SaveDataController();
        //save����
        //saveDataController.save(saveDataPath);
        Debug.Log("save�ł��܂���");
    }
}
