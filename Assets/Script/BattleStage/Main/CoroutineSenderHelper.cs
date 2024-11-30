using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public static class CoroutineSenderHelper
{
    /// <summary>
    /// Sender����肭���΂��Ȃ��������ߋ��ʉ�������������
    /// </summary>
    public static IEnumerator waitSbuscribe(Func<bool> condition,Action subscribe)
    {
        while (!condition())
        {
            yield return null;
        }
        subscribe?.Invoke();
    }
}
