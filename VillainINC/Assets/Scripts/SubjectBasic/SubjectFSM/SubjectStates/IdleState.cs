using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.IDLE);
    }
}
