using UnityEngine;

public class SpikeBasic : ClickableTrapBasic, ISlayer
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D slayCollider;

    [SerializeField] private ESubjectAnimation eSubjectAnimation;
    
    private bool isUsed = false;
    
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(eSubjectAnimation, OnAnimationFinished: () =>
        {
            subjectBasic.SubjectDieBehaviour.PlayerDie();
        });
    }

    public override void TrapClicked()
    {
        if (!isUsed)
        {
            isUsed = true;
            slayCollider.enabled = true;
            this.PlayAndCheckAnimationFinish(animator, "Do", () =>
            {
                slayCollider.enabled = false;
            });
        }
    }
}
