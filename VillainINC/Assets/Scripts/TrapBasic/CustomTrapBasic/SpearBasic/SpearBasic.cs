using System.Collections;
using UnityEngine;

public class SpearBasic : TrapBasic, ISlayer
{
    [SerializeField] private Rigidbody2D spearRigidbody2D;
    [SerializeField] private BoxCollider2D spearSlayCollider2D;
    [SerializeField] private BoxCollider2D spearBodyCollider2D;
    public void Slay(SubjectBasic subjectBasic)
    {
        subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
        subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.DIE_SHOT, OnAnimationFinished: 
            () =>
        {
            subjectBasic.SubjectDieBehaviour.SubjectDie();
        });

        ChangeLayerToSpear();
    }

    public IEnumerator AddForceUntilCrush(Vector2 spearForce)
    {
        while (true)
        {
            AddForeToSpear(spearForce);
            yield return null;
        }
    }

    public void ChangeLayerToSpear()
    {
        spearBodyCollider2D.gameObject.layer = LayerMask.NameToLayer("Spear");
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
