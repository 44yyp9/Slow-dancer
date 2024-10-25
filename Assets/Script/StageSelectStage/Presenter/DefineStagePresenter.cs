using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DefineStagePresenter : MonoBehaviour
{
    [SerializeField] private DecisionStage decisionStage;
    public void defineStage()
    {
        decisionStage.loadScene();
    }
}
