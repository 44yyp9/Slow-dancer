using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultStandingPictureView : MonoBehaviour
{
    public ReactiveProperty<GameObject> standingPicture;
    [SerializeField] private Vector3 picturePosi = new Vector3();
    public void showStandingPicture()
    {
        //�C���X�^���X��
        Instantiate(standingPicture.Value,picturePosi, Quaternion.identity);
    }
}
