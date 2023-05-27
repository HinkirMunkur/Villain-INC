using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : SubjectState
{    
    public override void Do()
    {
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.FALL);
    }

    public override void Done()
    {
        subjectBasic.MovementBehaviour.FallSpeed = 0;
        subjectBasic.MovementBehaviour.IsInAir = false;
    }

    public override void GoRun(IContext<ESubjectState> context)
    {
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            base.GoRun(context);
        });
    }
    
    public override void GoIdle(IContext<ESubjectState> context)
    {
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            base.GoIdle(context);
        });
    }

    public override void GoPush(IContext<ESubjectState> context)
    {
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            base.GoPush(context);
        });
    }
    public override void GoFall(IContext<ESubjectState> context) { }
}
