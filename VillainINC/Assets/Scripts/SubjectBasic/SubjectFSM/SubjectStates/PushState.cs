using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.PushItemSubject();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.PUSH);
    }
}
