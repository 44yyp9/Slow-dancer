using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using RhythmGameScene;

public abstract class InputHandlerBase
{
    //�R���g���[���[�̓��̓��t�@�����X��https://docs.unity3d.com/ja/2022.3/Manual/ios-handle-game-controller-input.html
    private string DPadX = "DPadX"; //�E��
    private string DPadY = "DPadY";
    //���ۂɔ�����Ƃ�̂͂��̃��\�b�h
    //��O�ł�������̂��߂�virtual��p����
    public virtual bool GetKey()
    {
        var isInputed =false;
        if (inputable())
        {
            isInputed = inputKey();
            if(!isInputed) isInputed =inputController();
        }
        return isInputed;
    }
    //�����������͂��ł��邩�ł��Ȃ����̔��f�����郍�W�b�N
    private bool inputable()
    {
        var _ =false;
        //�Q�[�������Ԃƃm�[�c���d�Ȃ��Ă��邩���̔���
        if (GameTime.playingTime != 0 && NoteHitterModel.isOverlaping)
        {
            _ = true;
        }
        return _;
    }
    //input�̒��g�ɃL�[��}�E�X��g�ݍ���
    public abstract bool inputKey();
    //�R���g���[���[���͂̏ꍇ�̑g�ݍ��ݗp
    public abstract bool inputController();
    //�����͑��N���X�ɏ����̂͂���
    //�ȍ~�̓p�b�h���͗p�̃��\�b�h
    public bool inputRightPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadY) > 0) //Input.GetKey(KeyCode.JoystickButton5)
        {
            _ =true;
            //Debug.Log("�E�����");
        }
        return _;
    }
    public bool inputLeftPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadY)<0)
        {
            _ = true;
            //Debug.Log("�������");
        }
        return _;
    }
    public bool inputUpPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadX) < 0)
        {
            _ = true;
            //Debug.Log("������");
        }
        return _;
    }
    public bool inputDownPad()
    {
        var _ = false;
        if (Input.GetAxis(DPadX) > 0)
        {
            _ = true;
            //Debug.Log("�������");
        }
        return _;
    }
}