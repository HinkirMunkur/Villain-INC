using Munkur;
using UnityEngine;

public class SpikeBasic : ClickableTrapBasic, ISlayer
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D slayCollider;

    [SerializeField] private ESubjectAnimation eSubjectAnimation;

    public void Slay(SubjectBasic subjectBasic)
    {
        AudioManager.Instance.PlaySoundEffect("SpikeHit");
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(eSubjectAnimation);
    }

    public override void TrapClicked()
    {
        AudioManager.Instance.PlaySoundEffect("Spike");
        slayCollider.enabled = true;
        this.PlayAndCheckAnimationFinish(animator, "Do", () =>
        {
            this.PlayAndCheckAnimationFinish(animator, "Done", () =>
            {
                slayCollider.enabled = false;
            });
        });
    }
}
