using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PossessionCostumes
{
    public static CostumeType nowCostume;
    public static Costumes possessionCostumes;
    //�������Costume��true�ɂ��郁�\�b�h
    public void setPossessionCostumes(CostumeType costumeType)
    {
        //�w�肵��Costume���t�B�[�h������
        string fieldName=costumeType.ToString();
        //���t���N�V�������g�p���t�B�[���h���擾
        //�t�B�[���h�����݂��Ȃ��ꍇnull��Ԃ�
        var field=typeof(Costumes).GetField(fieldName);
        if (field != null)
        {
            bool costumeValue = (bool)field.GetValue(possessionCostumes);
            if (!costumeValue)
            {
                field.SetValueDirect(__makeref(possessionCostumes), true);
            }
        }
    }
    //nowCostume���������Costume�ɂȂ郁�\�b�h
    public void setPlayerNowCostume(CostumeType costumeType)
    {
        var possessionCostume=booleanCostume(costumeType);
        if (!possessionCostume) return;
        nowCostume = costumeType;
    }
    //�������Costume��PossessionCosumes�ł�true��false�ł��邩�m�F�ł���֐�
    public bool booleanCostume(CostumeType costumeType)
    {
        //�w�肵��Costume���t�B�[�h������
        string fieldName = costumeType.ToString();
        //���t���N�V�������g�p���t�B�[���h���擾
        //�t�B�[���h�����݂��Ȃ��ꍇnull��Ԃ�
        var field = typeof(Costumes).GetField(fieldName);
        bool costumeValue = false;
        if (field != null)
        {
            costumeValue = (bool)field.GetValue(possessionCostumes);
        }
        return costumeValue;
    }
}
public enum CostumeType
{
    Normal,
    Costume1,
    Costume2
}
public struct Costumes
{
    public bool Normal;
    public bool Costume1;
    public bool Costume2;
}
