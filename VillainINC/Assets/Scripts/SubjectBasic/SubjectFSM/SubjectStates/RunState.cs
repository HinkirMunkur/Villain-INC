using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.RunSubject();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.RUN);
    }
}
