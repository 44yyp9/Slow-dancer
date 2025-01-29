using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CostumeSelectingOptonModel : MonoBehaviour, ISabWindowControllerable
{
    [SerializeField] private GameObject costumeWindow;
    public void openWindow()
    {
        costumeWindow.SetActive(true);
    }
    public void closeWindow()
    {
        costumeWindow.SetActive(false);
    }
}
