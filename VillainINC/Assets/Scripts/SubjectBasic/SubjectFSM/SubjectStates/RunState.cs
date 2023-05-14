using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.IsInAir = false;
        subjectBasic.MovementBehaviour.FallSpeed = 0;
        subjectBasic.MovementBehaviour.RunSubject();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.RUN);
    }

    public override void GoRun(IContext<ESubjectState> context) { }
}
