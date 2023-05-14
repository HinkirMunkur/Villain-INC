using Munkur;

public enum ESubjectAnimation
{
    IDLE,
    RUN,
    FALL,
    PUSH,
    JUMP,
    LAND,
    DIE_CRUSHED,
    DIE_SHOT,
    DIE_IMPALE_ABOVE,
    DIE_IMPALE_BELOW
}

public class SubjectAnimationController : AnimationController<ESubjectAnimation>
{
    
}
