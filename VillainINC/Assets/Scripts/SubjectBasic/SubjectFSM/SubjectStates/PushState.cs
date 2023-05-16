using System.Collections;
using UnityEngine;

public class PushState : SubjectState
{
    [SerializeField] private float pushTime;

    private WaitForSeconds wfs;
    private void Awake()
    {
        wfs = new WaitForSeconds(pushTime);
    }

    public override void Do()
    {
        subjectBasic.MovementBehaviour.PushSteady();
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.PUSH);

        StartCoroutine(PushTimeUntilRelease());
    }

    public override void Done()
    {
        StopAllCoroutines();
    }

    private IEnumerator PushTimeUntilRelease()
    {
        Vector3 pos = subjectBasic.transform.position;
        
        yield return wfs;

        if (subjectBasic.transform.position != pos)
        {
            StartCoroutine(PushTimeUntilRelease());
        }
        else
        {
            subjectBasic.MovementBehaviour.RotateSubject();
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
    }
}
