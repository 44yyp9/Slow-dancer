using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputPlayerManeger
{
    private List<InputHandlerBase> inputHandlers;
    private Dictionary<Type, bool> inputResults;
    public InputPlayerManeger()
    {
        inputHandlers = new List<InputHandlerBase>
        {
            //InputHanlerBase���p�����Ă�N���X�͑S�ď���
            new InputForwardRunHandler(),
            new InputIdelHandler(),
            new InputForwardAttackHandler(),
            new InputUpForwardJumpHandler(),
            new InputDownForwardJumpHandler(),
            new InputJumpHandler()
        };
        inputResults = new Dictionary<Type, bool>();
        Debug.Log("InputPlayerManeger Instance Created");
    }
    //���͂��X�V���郁�\�b�h
    public void updateInputs()
    {
        inputResults.Clear();
        foreach (var handler in inputHandlers)
        {
            inputResults[handler.GetType()]=handler.GetKey();
        }
    }
    //���͌��ʂ��擾
    public bool getInput<T>() where T : InputHandlerBase
    {
        return inputResults.TryGetValue(typeof(T),out var result) &&result;
    }
    //�o�^����Ă��郁�\�b�h�ŉ����܂܂�Ă�����̂�����ꍇ��true
    public bool anyInput()
    {
        return inputResults.ContainsValue(true);
    }
}
public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    // �T�[�r�X��o�^����
    public static void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }

    // �T�[�r�X���擾����
    public static T Get<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }
        throw new Exception($"Service of type {typeof(T)} is not registered.");
    }

    // �T�[�r�X���o�^����Ă��邩�m�F
    public static bool IsRegistered<T>()
    {
        return services.ContainsKey(typeof(T));
    }
}
