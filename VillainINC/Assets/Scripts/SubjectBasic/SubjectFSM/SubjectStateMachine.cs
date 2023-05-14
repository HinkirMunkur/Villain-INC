using System;
using System.Collections;
using System.Collections.Generic;
using Munkur;
using UnityEngine;

public enum ESubjectState
{
    IDLE,
    RUN,
    FALL,
    JUMP,
    PUSH
}

public class SubjectStateMachine : StateMachine<ESubjectState>
{
    [SerializeField] private ESubjectState startEState;

    protected override void Awake()
    {
        base.Awake();
        stateTransitionDictionary = new Dictionary<ESubjectState, Action>()
        {
            { ESubjectState.IDLE, GoIdle },
            { ESubjectState.RUN, GoRun },
            { ESubjectState.FALL, GoFall },
            { ESubjectState.JUMP, GoJump },
            { ESubjectState.PUSH, GoPush }
        };
    }

    private void Start()
    {
        SetState(startEState);
    }
    
    private void GoIdle() => ((SubjectState)currentState).GoIdle(this);
    private void GoRun() => ((SubjectState)currentState).GoRun(this);
    private void GoFall() => ((SubjectState)currentState).GoFall(this);
    private void GoJump() => ((SubjectState)currentState).GoJump(this);
    private void GoPush() => ((SubjectState)currentState).GoPush(this);


}
