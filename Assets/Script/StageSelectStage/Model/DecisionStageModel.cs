using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class DecisionStageModel : MonoBehaviour
{
    [SerializeField] private StagesMapModel stagesMapModel;
    public void decideStage()
    {
        var playerPosition = PlayerMapPositionModel.playerMapPositon;
        var stageName=stagesMapModel.getStageName(playerPosition);
        //シーンに飛ぶ
        try
        {
            SceneManager.LoadScene(stageName);
        }
        catch
        {
            Debug.Log("このシーン名が存在しませんでした");
        }
    }
}
