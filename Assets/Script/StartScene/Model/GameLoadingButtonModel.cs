using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameLoadingButtonModel : MonoBehaviour,ISabWindowControllerable
{
    [SerializeField] private GameObject loadingOptions;
    public void openWindow()
    {
        loadingOptions.SetActive(true);
    }
    public void closeWindow()
    {
        loadingOptions.SetActive(false);
    }
}
