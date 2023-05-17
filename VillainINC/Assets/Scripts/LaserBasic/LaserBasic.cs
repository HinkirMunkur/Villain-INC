using UnityEngine;

public class LaserBasic : ClickableTrapBasic, ISlayer
{
    [SerializeField] private Clickable laserClick;
    public Clickable LaserClick => laserClick;

    [SerializeField] private LaserBehaviour laserBehaviour;

    [SerializeField] private bool alwaysShoot;
    public bool AlwaysShoot => alwaysShoot;
    
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.DIE_SHOT, 
            OnAnimationFinished: () =>
            {
                subjectBasic.SubjectDieBehaviour.SubjectDie();
            });
    }
    public override void TrapClicked()
    {
        laserBehaviour.ShootLaserCoroutine();
    }
}
