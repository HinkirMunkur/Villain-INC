using UnityEngine;

public class BoxBasic : TrapBasic, ISlayer
{
    [SerializeField] private Rigidbody2D boxRigidbody2D;

    public void SetBoxStatic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Static;
    }
    
    public void SetBoxDynamic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
    
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(ESubjectAnimation.DIE_CRUSHED);
    }
}
