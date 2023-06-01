using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : SubjectState
{    
    public override void Do()
    {
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.FALL);

        Debug.Log(subjectBasic.MovementBehaviour.IsInAir);

        if (!subjectBasic.MovementBehaviour.IsInAir) 
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
    }

    public override void Done()
    {
        subjectBasic.MovementBehaviour.FallSpeed = 0;
    }

    public override void GoRun(IContext<ESubjectState> context)
    {
        subjectBasic.FeetTriggerHandler.gameObject.SetActive(false);
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            subjectBasic.FeetTriggerHandler.gameObject.SetActive(true);
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
        subjectBasic.FeetTriggerHandler.gameObject.SetActive(false);
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.LAND, OnAnimationFinished: () =>
        {
            subjectBasic.FeetTriggerHandler.gameObject.SetActive(true);
            base.GoPush(context);
        });
    }
    public override void GoFall(IContext<ESubjectState> context) { }
}
