using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class UIScoreModel : MonoBehaviour
{
    [SerializeField] private UIComboModel comboModel;
    [SerializeField] private UICoinModel coinModel;
    public ReactiveProperty<int> score = new ReactiveProperty<int>(0);
    public static int _score = 0;
    private UIScoreSliderModel sliderModel;
    private void Start()
    {
        //�����l�̐ݒ�
        _score = 0;
        subscribeCombo();
        subscribeCoin();
        sliderModel = new UIScoreSliderModel(SliderBaseSprite, SliderSpreite, Sliders, ScoreRank);
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
            _score=score.Value;
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
            _score=score.Value;
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
    [Header("Slider�ɂ��Ă�Inspector")]
    [SerializeField] private Image SliderBaseSprite;
    [SerializeField] private Image SliderSpreite;
    [SerializeField] private List<Sprite> Sliders;
    [SerializeField] private List<int> ScoreRank;
    public float IsSliderValue()
    {
        var _value = sliderModel.IsSliderValue(score.Value);
        return _value;
    }
}
