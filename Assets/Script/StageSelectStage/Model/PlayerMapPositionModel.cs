using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMapPositionModel : MonoBehaviour
{
    //player�̈ʒu���
    public ReactiveProperty<Vector3> playerVectorPosition;
    public static int playerMapPositon; //�V���O���g���ł��ł�save,load�ɑΉ��ł���悤�ɂ���
    public ReactiveProperty<int> ObservablePlayerMapPosition=new ReactiveProperty<int>(playerMapPositon);
    //�R���|�[�l���g�̎擾
    [SerializeField] private StagesMapModel stagesMapModel;
    public void forwardStage()
    {
        if (StagesMapModel.opendStage < playerMapPositon + 1) return;
        playerMapPositon += 1;
        movePlayerVector();
    }
    public void backStage()
    {
        if(playerMapPositon<=0) return;
        playerMapPositon -= 1;
        movePlayerVector();
    }
    public void movePlayerVector()
    {
        var mapPosition=playerMapPositon;
        //�{���ǂ��Ȃ���playerMapPosition��ObservablePlayerMapPosition���Ȃ����킹��
        ObservablePlayerMapPosition.Value=mapPosition;
        var vectorPosition = stagesMapModel.isStagePosition(mapPosition);
        playerVectorPosition.Value =vectorPosition;
    }
}
