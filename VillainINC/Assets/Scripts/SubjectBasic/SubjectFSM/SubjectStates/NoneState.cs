using UnityEngine;

public class NoneState : SubjectState
{
    public override void Do()
    {
        subjectBasic.MovementBehaviour.ChangeVelocity(Vector2.zero);
    }

    public override void GoNone(IContext<ESubjectState> context) { }
    public override void GoIdle(IContext<ESubjectState> context) { }
    public override void GoRun(IContext<ESubjectState> context) { }
    public override void GoFall(IContext<ESubjectState> context) { }
    public override void GoJump(IContext<ESubjectState> context) { }
    public override void GoPush(IContext<ESubjectState> context) { }
}
