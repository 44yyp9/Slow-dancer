using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultStandingPictureModel : MonoBehaviour
{
    [SerializeField] ResultScoreModel scoreModel;
    [SerializeField] private GameObject[] sprites=new GameObject[6];
    public ReactiveProperty<GameObject> sprite;
    public void setStandingPicture()
    {
        var rank = scoreModel.getRank(UIScoreModel._score);
        if (rank == ResultedRank.E) sprite.Value = sprites[0];
        if (rank == ResultedRank.D) sprite.Value = sprites[1];
        if (rank == ResultedRank.C) sprite.Value = sprites[2];
        if (rank == ResultedRank.B) sprite.Value = sprites[3];
        if (rank == ResultedRank.A) sprite.Value = sprites[4];
        if (rank == ResultedRank.S) sprite.Value = sprites[5];
    }
}
