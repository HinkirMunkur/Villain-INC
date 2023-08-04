using UnityEngine;

public class MunkurTextController : MonoBehaviour
{
    [SerializeField] private Transform lastPos;
    [SerializeField] private SubjectBasic subjectBasic;
    
    private bool oneTime = false;
    
    private void Start()
    {
        subjectBasic.MovementBehaviour.RotateSubject();
    }

    private void Update()
    {
        if (!oneTime && (transform.position.x < lastPos.transform.position.x))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.IDLE);
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        }
    }
}
