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
        //ここにDotweenでアニメーション
        ScoreSlider.value = _value;
    }
}
