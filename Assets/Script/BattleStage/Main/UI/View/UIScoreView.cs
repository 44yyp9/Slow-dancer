using UnityEngine;
using UnityEngine.UI;

public class UIScoreView : UIView
{
    [SerializeField] private Slider ScoreSlider;
    public override void upPointAnimation()
    {
        
    }
    public override void downPointAnimation()
    {
        
    }
    public void setScoreValue(float _value)
    {
        //������Dotween�ŃA�j���[�V����
        ScoreSlider.value = _value;
    }
}
