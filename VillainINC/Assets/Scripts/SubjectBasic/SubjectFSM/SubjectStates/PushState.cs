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
        subjectBasic.SubjectAudio.PushAudio();
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
        float threshold = 0.1f;
        
        yield return wfs;

        if (subjectBasic.transform.position.x > pos.x + threshold || subjectBasic.transform.position.x < pos.x - threshold)
        {
            StartCoroutine(PushTimeUntilRelease());
        }
        else
        {
            subjectBasic.MovementBehaviour.RotateSubject();
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
    }

    public override void GoPush(IContext<ESubjectState> context) { }
}
