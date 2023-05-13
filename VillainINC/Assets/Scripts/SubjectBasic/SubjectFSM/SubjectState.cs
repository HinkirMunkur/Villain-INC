using UnityEngine;

public abstract class SubjectState : State
{
    [SerializeField] protected SubjectBasic subjectBasic;

    public virtual void GoIdle(IContext<ESubjectState> context) { context.SetState(ESubjectState.IDLE); }
    public virtual void GoRun(IContext<ESubjectState> context) { context.SetState(ESubjectState.RUN); }
    public virtual void GoFall(IContext<ESubjectState> context) { context.SetState(ESubjectState.FALL); }
    public virtual void GoJump(IContext<ESubjectState> context) { context.SetState(ESubjectState.JUMP); }
    public virtual void GoPush(IContext<ESubjectState> context) { context.SetState(ESubjectState.PUSH); }
}
