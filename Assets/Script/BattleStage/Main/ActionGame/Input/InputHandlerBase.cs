using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class InputHandlerBase
{
    //���ۂɔ�����Ƃ�̂͂��̃��\�b�h
    public bool GetKey()
    {
        var _ =false;
        if (GameTime.playingTime != 0)
        {
            _ = input();
        }
        return _;
    }
    //input�̒��g�ɃL�[��}�E�X��g�ݍ���
    public abstract bool input();
}
