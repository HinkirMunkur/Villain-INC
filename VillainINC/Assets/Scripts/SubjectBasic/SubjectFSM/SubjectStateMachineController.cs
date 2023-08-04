using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectStateMachineController : MonoBehaviour
{
    [SerializeField] private SubjectStateMachine subjectStateMachine;

    public void DoTransition(ESubjectState subjectState)
    {
        subjectStateMachine.DoStateTransition(subjectState);
    }

    public ESubjectState GetCurrentState()
    {
        return subjectStateMachine.ECurrState;
    }
}
