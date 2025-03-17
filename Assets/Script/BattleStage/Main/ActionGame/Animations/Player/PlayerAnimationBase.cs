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
    [Header("CrossFade�ŗp����萔")]
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
            //�����Ɏ��S�A�j���[�V�����𗬂�����������
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
        animationTime = 0.5f;//���u��
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
        progressesTime = 0; //�i�݋��m�邽�߂̎���
        this.animationLength = animationLength; //�A�j���[�V�����̒������擾
        //�R���[�`���̔��˂̎����ɂ��e���|������Ȃ��ʒu�������Ă��܂��o�O������
        setAnimationTime();
        var delayAnimation = getAnimationTime() * 1.5f;
        speedScale = (this.animationLength /delayAnimation); //�A�j���[�V�����̑����𒲐�
        animationManeger.playerAnimator.speed = speedScale;
    }
    //sin�g��p�����ɋ}��t�����A�j���[�V�����̎������s��
    public void setSineAnimation()
    {
        progressesTime += GameTime.playingTime;
        // �T�C���g�̐U��
        float amplitude = speedScale * animationLength * Mathf.PI;
        amplitude /= 4;
        // �T�C���g�̎��g��
        float frequency = Mathf.PI/animationLength;
        float sine = Mathf.Sin(progressesTime * frequency);
        if (sine <= 0)
        {
            transNextAnimation(PlayerAnimatioName.Idel.ToString());
            return;
        }
        //�v�Z�͐������͂��Ȃ̂ɏ�肭�s���Ȃ�
        var scale = sine * amplitude * 4f;
        animationManeger.playerAnimator.speed = scale;
    }
    //�T�C���g��ėp�I�Ɏg�������Ƃ��Ɏg��
    public float calculationSine(float scale)
    {
        progressesTime += GameTime.playingTime;
        // �T�C���g�̐U��
        float amplitude = speedScale * animationLength * Mathf.PI;
        amplitude /= 4;
        // �T�C���g�̎��g��
        float frequency = Mathf.PI / animationLength;
        float sine = Mathf.Sin(progressesTime * frequency);
        if (sine <= 0) sine = 0;
        //�v�Z�͐������͂��Ȃ̂ɏ�肭�s���Ȃ�
        var sineX = sine * amplitude * scale;
        return sineX;
    }
    //AnimationSpeed�����̃A�j���[�V�����ɍs���Ƃ���1�ɖ߂�
    private void resetAnimationSpeed()
    {
        animationManeger.playerAnimator.speed = 1f;
    }
    public abstract void nextAnimation();
    public abstract void movePosition();
}
