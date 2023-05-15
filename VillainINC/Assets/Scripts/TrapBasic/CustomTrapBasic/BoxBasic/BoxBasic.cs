using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBasic : TrapBasic, ISlayer
{
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.DIE_CRUSHED, 
            OnAnimationFinished: () =>
        {
            subjectBasic.SubjectDieBehaviour.PlayerDie();
        });
    }
}
