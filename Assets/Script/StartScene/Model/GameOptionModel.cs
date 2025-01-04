using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameOptionModel : MonoBehaviour,ISabWindowControllerable
{
    [SerializeField] private GameObject options;
    public void openWindow()
    {
        options.SetActive(true);
    }
    public void closeWindow()
    {
        options?.SetActive(false);
    }
}
