using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMapPositionModel : MonoBehaviour
{
    //playerの位置情報
    public ReactiveProperty<Vector3> playerVectorPosition;
    public static int playerMapPositon; //シングルトンでいつでもsave,loadに対応できるようにする
    public ReactiveProperty<int> ObservablePlayerMapPosition=new ReactiveProperty<int>(playerMapPositon);
    //コンポーネントの取得
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
        //本来良くないがplayerMapPositionとObservablePlayerMapPositionをつなぎ合わせる
        ObservablePlayerMapPosition.Value=mapPosition;
        var vectorPosition = stagesMapModel.isStagePosition(mapPosition);
        playerVectorPosition.Value =vectorPosition;
    }
}
