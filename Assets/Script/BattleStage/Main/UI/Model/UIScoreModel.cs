using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIScoreModel : MonoBehaviour
{
    [SerializeField] private UIComboModel comboModel;
    [SerializeField] private UICoinModel coinModel;
    public ReactiveProperty<int> score = new ReactiveProperty<int>(0);
    private void Start()
    {
        subscribeCombo();
        subscribeCoin();
    }
    private void subscribeCombo()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition: () => comboModel.combo != null,
            subscribe:() =>
            {
                _combo = new ReactiveProperty<int>(comboModel.combo.Value);
                comboModel.combo.Subscribe(_ => combo = comboModel.combo).AddTo(this);
            }
            )) ;
    }
    private void subscribeCoin()
    {
        StartCoroutine(CoroutineSenderHelper.waitSbuscribe(
            condition:() => coinModel.totalCoin != null,
            subscribe:() =>
            {
                _totalCoin = new ReactiveProperty<int>(coinModel.totalCoin.Value);
                coinModel.totalCoin.Subscribe(_ => totalCoin = coinModel.totalCoin).AddTo(this);
            }
            ));
    }
    private ReactiveProperty<int> _combo;
    private ReactiveProperty<int> combo
    {
        get { return _combo; }
        set
        {
            var increment = value.Value - _combo.Value;
            score.Value += addCombo(increment);
            _combo.Value = value.Value;
        }
    }
    private ReactiveProperty<int> _totalCoin;
    private ReactiveProperty<int> totalCoin
    {
        get { return _totalCoin; }
        set
        {
            var increment = value.Value - _totalCoin.Value;
            score.Value += addCoin(increment);
            _totalCoin.Value = value.Value;
        }
    }
    private int addCoin(int increment)
    {
        if(increment<=0) increment = 0;
        increment *= 10;
        return increment;
    }
    private int addCombo(int increment)
    {
        if(increment<=0) increment = 0;
        increment *= 5;
        return increment;
    }
}
