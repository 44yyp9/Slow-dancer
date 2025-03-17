using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class PlayerAnimationBase:StateMachineBehaviour
{
    public PlayerAnimationManeger animationManeger;
    public InputPlayerManeger inputManeger;
    public const float moveing_x = 10f;
    public const float moveing_y = 10f;
    [Header("CrossFadeで用いる定数")]
    private float fadeTime = 0f;
    public void setManeger(Animator animator)
    {
        animationManeger=animator.GetComponent<PlayerAnimationManeger>();
        inputManeger=ServiceLocator.Get<InputPlayerManeger>();
    }
    public void deadAnimation()
    {
        if (animationManeger.isPlayerHP() <= 0)
        {
            //ここに死亡アニメーションを流す実装をする
            animationManeger.playerAnimator.Play("");
        }
    }
    public void transNextAnimation(string name)
    {
        resetAnimationSpeed();
        animationManeger.playerAnimator.Play(name, 0, 0f);
    }
    private float animationTime = NotesGenerateView.delayTime;
    private void setAnimationTime()
    {
        /*
        animationTime = NotesGenerateView.delayTime;
        animationTime -= fadeTime;
        */
        animationTime = 0.5f;//仮置き
    }
    private float getAnimationTime()
    {
        return animationTime;
    }
    private float animationLength;
    private float speedScale;
    private float progressesTime;
    public void setAnimationSpeed(float animationLength)
    {
        progressesTime = 0; //進み具合を知るための実装
        this.animationLength = animationLength; //アニメーションの長さを取得
        //コルーチンの発射の実装によりテンポが合わない位置が生じてしまうバグがある
        setAnimationTime();
        var delayAnimation = getAnimationTime() * 1.5f;
        speedScale = (this.animationLength /delayAnimation); //アニメーションの速さを調整
        animationManeger.playerAnimator.speed = speedScale;
    }
    //sin波を用いた緩急を付けたアニメーションの実装を行う
    public void setSineAnimation()
    {
        progressesTime += GameTime.playingTime;
        // サイン波の振幅
        float amplitude = speedScale * animationLength * Mathf.PI;
        amplitude /= 4;
        // サイン波の周波数
        float frequency = Mathf.PI/animationLength;
        float sine = Mathf.Sin(progressesTime * frequency);
        if (sine <= 0)
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
            return;
        }
        //計算は正しいはずなのに上手く行かない
        var scale = sine * amplitude * 4f;
        animationManeger.playerAnimator.speed = scale;
    }
    //サイン波を汎用的に使いたいときに使う
    public float calculationSine(float scale)
    {
        progressesTime += GameTime.playingTime;
        // サイン波の振幅
        float amplitude = speedScale * animationLength * Mathf.PI;
        amplitude /= 4;
        // サイン波の周波数
        float frequency = Mathf.PI / animationLength;
        float sine = Mathf.Sin(progressesTime * frequency);
        if (sine <= 0) sine = 0;
        //計算は正しいはずなのに上手く行かない
        var sineX = sine * amplitude * scale;
        return sineX;
    }
    //AnimationSpeedを次のアニメーションに行くときに1に戻す
    private void resetAnimationSpeed()
    {
        animationManeger.playerAnimator.speed = 1f;
    }
    public abstract void nextAnimation();
    public abstract void movePosition();
}
