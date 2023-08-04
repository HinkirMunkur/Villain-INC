using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.JumpSubject();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.JUMP, OnAnimationFinished: () => {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.FALL);
        });
    }
    
    public override void GoRun(IContext<ESubjectState> context) { }
    public override void GoIdle(IContext<ESubjectState> context) { }
    public override void GoPush(IContext<ESubjectState> context) { }
    
}
