using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PossessionCostumes
{
    public static CostumeType nowCostume;
    public static Costumes possessionCostumes;
    //代入したCostumeをtrueにするメソッド
    public void setPossessionCostumes(CostumeType costumeType)
    {
        //指定したCostumeをフィード化する
        string fieldName=costumeType.ToString();
        //リフレクションを使用しフィールドを取得
        //フィールドが存在しない場合nullを返す
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
    //nowCostumeが代入したCostumeになるメソッド
    public void setPlayerNowCostume(CostumeType costumeType)
    {
        var possessionCostume=booleanCostume(costumeType);
        if (!possessionCostume) return;
        nowCostume = costumeType;
    }
    //代入したCostumeがPossessionCosumesではtrueかfalseであるか確認できる関数
    public bool booleanCostume(CostumeType costumeType)
    {
        //指定したCostumeをフィード化する
        string fieldName = costumeType.ToString();
        //リフレクションを使用しフィールドを取得
        //フィールドが存在しない場合nullを返す
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
