using System;
using System.Collections;
using System.Collections.Generic;
using Munkur;
using UnityEngine;

public enum ESubjectState
{
    NONE,
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
            { ESubjectState.NONE, GoNone },
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
    
    private void GoNone() => ((SubjectState)currState).GoNone(this);
    private void GoIdle() => ((SubjectState)currState).GoIdle(this);
    private void GoRun() => ((SubjectState)currState).GoRun(this);
    private void GoFall() => ((SubjectState)currState).GoFall(this);
    private void GoJump() => ((SubjectState)currState).GoJump(this);
    private void GoPush() => ((SubjectState)currState).GoPush(this);


}
