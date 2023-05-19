using UnityEngine;

public class FeetTriggerHandler : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Box"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
        else if (col.CompareTag("Tramboline"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.JUMP);
        }
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        subjectBasic.MovementBehaviour.IsInAir = true;
        StartCoroutine(subjectBasic.MovementBehaviour.FindFallSpeed());

    }
}
