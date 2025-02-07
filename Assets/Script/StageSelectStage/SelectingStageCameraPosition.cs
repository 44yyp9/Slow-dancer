using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectingStageCameraPosition : MonoBehaviour,ICameraPositionable
{
    [SerializeField] private GameObject camera;
    [SerializeField] private PlayerMapPositionModel playerPositionModel;
    [SerializeField] private PlayerMapPositionView playerPositionView;
    public Vector2 isCameraPosition()
    {
        var position = camera.transform.position;
        position.x = playerPositionModel.playerVectorPosition.Value.x;
        position.y=playerPositionModel.playerVectorPosition.Value.y;
        return position;
    }
    public void adulationAnimation()
    {
        StartCoroutine(delayTime(0.2f));
        //‚±‚±‚Ìmodel‚ÆView‚ÍãŽè‚­”­‰Î‚·‚é‚©•ª‚©‚ç‚È‚¢‚©‚ç’ˆÓ
        playerPositionView.moveAnimetion(playerPositionView.playerPosition.Value, playerPositionModel.playerVectorPosition.Value);
    }
    IEnumerator delayTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    public void adulationCamera()
    {
        playerPositionModel.ObservablePlayerMapPosition.Subscribe( _ => adulationAnimation()).AddTo(this);
    }
}
