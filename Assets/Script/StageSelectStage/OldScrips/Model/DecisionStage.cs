using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class DecisionStage : MonoBehaviour
{
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private Map map;
    public void loadScene()
    {
        var posi = playerPosition.currentStage.Value;
        var stageObj = map.stages[posi];
        var _stageObj = stageObj.GetComponent<StageBase>();
        var stageName = _stageObj.stageName;
        SceneManager.LoadScene(stageName);
    }
}
