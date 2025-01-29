using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StagesMapModel : MonoBehaviour
{
    public static int opendStage = 2; //save,load�ŏ㏑���ł���悤�ɂ���
    public List<GameObject> Stages; //�X�e�[�W��+Scene��SceneName�ɂ���
    //�w�肵���X�e�[�W�̈ʒu��Ԃ�
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
