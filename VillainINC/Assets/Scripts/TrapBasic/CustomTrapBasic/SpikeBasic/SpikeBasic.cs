using UnityEngine;

public class SpikeBasic : ClickableTrapBasic, ISlayer
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D slayCollider;

    [SerializeField] private ESubjectAnimation eSubjectAnimation;

    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(eSubjectAnimation, OnAnimationFinished: () =>
        {
            subjectBasic.SubjectDieBehaviour.SubjectDie();
        });
    }

    public override void TrapClicked()
    {
        slayCollider.enabled = true;
        this.PlayAndCheckAnimationFinish(animator, "Do", () =>
        {
            slayCollider.enabled = false;
        });
    }
}
