using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.RunSteady();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.RUN);
    }

    public override void GoRun(IContext<ESubjectState> context) { }
}
