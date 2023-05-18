using UnityEngine;

public class SpikeBasic : ClickableTrapBasic, ISlayer
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D slayCollider;

    [SerializeField] private ESubjectAnimation eSubjectAnimation;

    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(eSubjectAnimation);
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
