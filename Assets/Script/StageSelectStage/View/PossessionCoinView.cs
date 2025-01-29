using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class PossessionCoinView : MonoBehaviour
{
    [Header("Š‚µ‚Ä‚¢‚éƒRƒCƒ“‚ğ•\¦‚·‚éText")]
    [SerializeField] private Text possessionCoinText;
    public ReactiveProperty<int> possessionCoin;
    public void desplayCoin()
    {
        possessionCoinText.text = possessionCoin.ToString();
    }
}
