using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : SubjectState
{
    public override void Do()
    {
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.FALL);
    }
    
    public override void GoRun(IContext<ESubjectState> context)
    {
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            base.GoRun(context);
        });
    }
    
    public override void GoIdle(IContext<ESubjectState> context)
    {
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            base.GoIdle(context);
        });
    }
    
    public override void GoPush(IContext<ESubjectState> context){ }
}
