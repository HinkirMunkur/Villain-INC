using Munkur;
using UnityEngine;

public class LaserBasic : AutomaticSystem, ISlayer
{
    [SerializeField] private LaserBehaviour laserBehaviour;

    [SerializeField] private bool alwaysShoot;
    public bool AlwaysShoot => alwaysShoot;
    
    public void Slay(SubjectBasic subjectBasic)
    {
        AudioManager.Instance.PlaySoundEffect("HitByLaser");
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(ESubjectAnimation.DIE_SHOT);
    }
    
    public override void RunSystem()
    {
        laserBehaviour.ShootLaserCoroutine();
    }

    public override void ExitSystem()
    {
        laserBehaviour.StopShootLaserCoroutine();
    }

    
}
