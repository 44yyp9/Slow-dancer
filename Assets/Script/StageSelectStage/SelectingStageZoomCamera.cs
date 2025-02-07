using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SelectingStageZoomCamera : MonoBehaviour,ICameraZoomable
{
    [SerializeField] private Camera camera;
    public void zoomin()
    {

    }
    public void zoomout()
    {

    }
    IEnumerator zoom(float feture_size)
    {
        float present_size = camera.orthographicSize;
        var difference=feture_size-present_size;
        //Ç‰Ç¡Ç≠ÇËÉYÅ[ÉÄÇµÇΩÇ¢
        yield return null;
    }
}
