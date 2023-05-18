using System.Collections;
using UnityEngine;

public class SpearBasic : TrapBasic, ISlayer
{
    [SerializeField] private Rigidbody2D spearRigidbody2D;
    [SerializeField] private CapsuleCollider2D spearSlayCollider2D;
    [SerializeField] private BoxCollider2D spearBodyCollider2D;
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectDieBehaviour.BeforeSubjectDie(ESubjectAnimation.DIE_SHOT);
    }

    public IEnumerator AddForceUntilCrush(Vector2 spearForce)
    {
        while (true)
        {
            AddForeToSpear(spearForce);
            yield return null;
        }
    }

    public void SetSpearStatic()
    {
        spearRigidbody2D.bodyType = RigidbodyType2D.Static;
    }
    
    public void SetSpearDynamic()
    {
        spearRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    public void EnableSpearSlayCollider()
    {
        spearSlayCollider2D.enabled = true;
    }
    
    public void DisableSpearSlayCollider()
    {
        spearSlayCollider2D.enabled = false;
    }

    public void AddForeToSpear(Vector2 force)
    {
        spearRigidbody2D.AddForce(force);
    }
}
