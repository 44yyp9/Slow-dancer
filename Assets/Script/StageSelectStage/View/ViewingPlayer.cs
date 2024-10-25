using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ViewingPlayer : MonoBehaviour
{
    [SerializeField]  private Map map;
    [SerializeField] private MapPresenter presenter;
    private ReactiveProperty<Transform> _playerPosi;
    public ReactiveProperty<Transform> playerPosi
    {
        get { return _playerPosi; }
        set 
        {
            if (_playerPosi != value)
            {
                _playerPosi = value;
                moveAnimation();
            }
        }
    }
    private void moveAnimation()
    {
        Transform posi = _playerPosi.Value;
        gameObject.transform.position = posi.position;
    }
    //ˆÚ“®ƒL[‚ÌŠÄŽ‹
    private void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.RightArrow)).Subscribe(_ => presenter.onForwardKey()).AddTo(this);
        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.LeftArrow)).Subscribe(_ => presenter.onBackKey()).AddTo(this);
    }
}
