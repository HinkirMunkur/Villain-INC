using UnityEngine;

public class HandTriggerHandler : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Box"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.PUSH);
        }
        else if (col.CompareTag("Wall"))
        {
            subjectBasic.MovementBehaviour.RotateSubject();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Box"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
    }
}
