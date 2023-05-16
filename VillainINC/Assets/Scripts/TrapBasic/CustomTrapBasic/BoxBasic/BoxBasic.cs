using UnityEngine;

public class BoxBasic : TrapBasic, ISlayer
{
    [SerializeField] private Rigidbody2D boxRigidbody2D;

    public void SetBoxStatic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Static;
    }
    
    public void SetBoxDynamic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
    
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.DIE_CRUSHED, 
            OnAnimationFinished: () =>
        {
            subjectBasic.SubjectDieBehaviour.SubjectDie();
        });
    }
}
