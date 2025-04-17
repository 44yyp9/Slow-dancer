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
            //InputHanlerBaseを継承してるクラスは全て書く
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
    //入力を更新するメソッド
    public void updateInputs()
    {
        inputResults.Clear();
        foreach (var handler in inputHandlers)
        {
            inputResults[handler.GetType()]=handler.GetKey();
        }
    }
    //入力結果を取得
    public bool getInput<T>() where T : InputHandlerBase
    {
        return inputResults.TryGetValue(typeof(T),out var result) &&result;
    }
    //登録されているメソッドで何か含まれているものがある場合はtrue
    public bool anyInput()
    {
        return inputResults.ContainsValue(true);
    }
}
public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    // サービスを登録する
    public static void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }

    // サービスを取得する
    public static T Get<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }
        throw new Exception($"Service of type {typeof(T)} is not registered.");
    }

    // サービスが登録されているか確認
    public static bool IsRegistered<T>()
    {
        return services.ContainsKey(typeof(T));
    }
}
