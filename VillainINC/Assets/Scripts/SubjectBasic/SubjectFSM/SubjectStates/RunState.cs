using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.IsInGround = true;
        subjectBasic.MovementBehaviour.RunSteady();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.RUN);
    }

    public override void Done()
    {
        subjectBasic.MovementBehaviour.IsInGround = false;
    }

    public override void GoRun(IContext<ESubjectState> context) { }
}
