using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DecsionStagePrensenter : MonoBehaviour
{
    [SerializeField] private DecisionStageModel model;
    [SerializeField] private DecisionStageView view;
    private void Start()
    {
        assginDecisionKey();
    }
    private void assginDecisionKey()
    {
        view.registerKeyAction(onDecistionKey: model.decideStage);
    }
}
