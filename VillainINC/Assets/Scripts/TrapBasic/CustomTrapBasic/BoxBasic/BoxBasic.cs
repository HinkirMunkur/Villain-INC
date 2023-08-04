using UnityEngine;
using Munkur;

public class BoxBasic : TrapBasic, ISlayer
{
    [SerializeField] private Rigidbody2D boxRigidbody2D;
    [SerializeField] private Vector2 force;

    public void SetBoxStatic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Static;
    }
    
    public void SetBoxDynamic()
    {
        boxRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        boxRigidbody2D.AddForce(force * Time.deltaTime);
    }
    
    public void Slay(SubjectBasic subjectBasic)
    {
        AudioManager.Instance.PlaySoundEffect("BoxHit");
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(ESubjectAnimation.DIE_CRUSHED);
    }
}
