using UnityEngine;

public class FeetTriggerHandler : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("PushBox"))
        {
            subjectBasic.MovementBehaviour.IsInGround = true;
            subjectBasic.HandTriggerHandler.gameObject.SetActive(true);
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
        else if (col.CompareTag("Tramboline"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.JUMP);
        }
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        if (col.CompareTag("Ground") || col.CompareTag("PushBox") || col.CompareTag("Tramboline")) 
        {
            subjectBasic.MovementBehaviour.IsInAir = true;
            subjectBasic.MovementBehaviour.IsInGround = false;
            subjectBasic.HandTriggerHandler.gameObject.SetActive(false);
            StartCoroutine(subjectBasic.MovementBehaviour.FindFallSpeed());
        }
    }
}
