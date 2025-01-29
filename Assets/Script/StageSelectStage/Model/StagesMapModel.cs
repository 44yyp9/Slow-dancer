using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StagesMapModel : MonoBehaviour
{
    public static int opendStage = 2; //save,loadで上書きできるようにする
    public List<GameObject> Stages; //ステージ名+SceneでSceneNameにする
    //指定したステージの位置を返す
    public Vector3 isStagePosition(int stageNumber)
    {
        var stage = Stages[stageNumber];
        var position = stage.transform.position;
        return position;
    }
    public string getStageName(int stageNumber)
    {
        var stage = Stages[stageNumber];
        var stageName = stage.name;
        var sceneName = stageName + "Scene";
        return sceneName;
    }
}
