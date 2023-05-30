using UnityEngine;

public class SubjectDieBehaviour : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private Transform deadParticle;
    
    public void BeforeSubjectDie(ESubjectAnimation eSubjectDieAnimation)
    {
        capsuleCollider2D.enabled = false;
        subjectBasic.MovementBehaviour.SubjectRigidbody2D.bodyType = RigidbodyType2D.Static;
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(eSubjectDieAnimation, 
            OnAnimationFinished: () =>
            {
                subjectBasic.SubjectDieBehaviour.SubjectDie();
            });
        
        Instantiate(deadParticle, subjectBasic.transform.position, Quaternion.identity);
    }
    private void SubjectDie()
    {
        Destroy(subjectBasic.gameObject);
        subjectBasic.SpawnPipeBasic.SpawnSubjectBasic();
    }
}
