using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SkyForwordRunAnimation : PlayerAnimationBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        setManeger(animator);
        setAnimationSpeed(stateInfo.length);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movePosition();
        nextAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void nextAnimation()
    {
        var isCombo = animationManeger.isCombo();
        //Handlerの実装は問題ないが、タグは今後変更するので注意が必要
        if (inputManeger.getInput<InputForwardAttackHandler>())
        {
            transNextAnimation(PlayerAnimatioName.Forward_Ground_Attack);
        }
        if (isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //実際はjamp中しかできないので注意
            transNextAnimation(PlayerAnimatioName.Forward_Run_Sky);
        }
        else if (!isCombo && inputManeger.getInput<InputForwardRunHandler>())
        {
            //実際はjamp中しかできないので注意
            transNextAnimation(PlayerAnimatioName.Miss_Forward_Run_Sky);
        }
        //落ちるアニメーションを追加したほうがいいかも
    }
    public override void movePosition()
    {
        var sineMovingX = calculationSine(3f);
        animationManeger.gameObject.transform.position += new Vector3(sineMovingX, 0, 0) * GameTime.playingTime * 10f;
        animationManeger.gameObject.transform.position += new Vector3(1.0f, 0, 0) * GameTime.playingTime * 2f;
    }
}
