using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public abstract class UIView : MonoBehaviour
{
    //value�̃e�L�X�g�ւ̔��f
    public Text point;
    /// <summary>
    /// �X�R�A�ȂǖڂɌ�����͈͐��lUI�𐧌䂷�邽�߂�SuperClass
    /// �p����͕K����ڂ̒l�̂ݐ��䂷��
    /// </summary>
    private ReactiveProperty<int> _veiwPoint=new ReactiveProperty<int>(0);
    public ReactiveProperty<int> viewPoint
    {
        get { return _veiwPoint; }
        set
        {
            var increment=value.Value-_veiwPoint.Value;
            if (increment < 0) downPointAnimation();
            else if (increment > 0) upPointAnimation();
            else if (increment == 0) Debug.Log("unchange");
            else
            {
                Debug.Log("error Point");
            }
            _veiwPoint.Value = value.Value;
            point.GetComponent<Text>().text = _veiwPoint.Value.ToString();
        }
    }
    abstract public void upPointAnimation();
    abstract public void downPointAnimation();
}
