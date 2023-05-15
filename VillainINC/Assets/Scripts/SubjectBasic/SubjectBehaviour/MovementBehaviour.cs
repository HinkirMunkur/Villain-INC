using System.Collections;
using UnityEngine;
using System;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    [SerializeField] private Rigidbody2D subjectRigidbody2D;
    public Rigidbody2D SubjectRigidbody2D => subjectRigidbody2D;
    
    [SerializeField] private float runSpeed;
    [SerializeField] private float pushSpeed;

    [SerializeField] private bool isInAir;
    public bool IsInAir 
    {
        get { return isInAir; }
        set { isInAir = value; }
    }

    private float _fallSpeed;
    public float FallSpeed 
    {
        set { _fallSpeed = value; }
    }
    private float _landLimit = -3f;

    private Vector2 subjectRunVelocity;
    private Vector2 subjectPushItemVelocity;
    private Vector2 subjectTrambolineForceEffect;
    
    private void Awake()
    {
        subjectRunVelocity = new Vector2(runSpeed, subjectRigidbody2D.velocity.y);
        subjectPushItemVelocity = new Vector2(pushSpeed, subjectRigidbody2D.velocity.y);
        subjectTrambolineForceEffect = new Vector2(Math.Sign(subjectRunVelocity.x) * 2, 4);
    }

    private void FixedUpdate()
    {
        subjectRigidbody2D.velocity = new Vector2(runSpeed, subjectRigidbody2D.velocity.y);
    }

    public void ChangeVelocity(Vector2 subjectVelocity)
    {
        subjectRigidbody2D.velocity = subjectVelocity;
    }

    public void RunSubject()
    {
        subjectRigidbody2D.velocity = subjectRunVelocity;
    }
    
    public void PushItemSubject()
    {
        subjectRigidbody2D.velocity = subjectPushItemVelocity;
    }
    
    public void RotateSubject()
    {
        subjectRunVelocity = (Vector2.left + Vector2.up) * subjectRunVelocity;
        subjectBasic.transform.Rotate(0, 180, 0);
        subjectRigidbody2D.velocity = subjectRunVelocity;
    }
    
    public void JumpSubject()
    {
        subjectRigidbody2D.AddForce(subjectTrambolineForceEffect * 40);
        //subjectRigidbody2D.velocity = subjectTrambolineForceEffect;
    }
    
    public void ChangeTrambolineEffect(Vector2 subjectForce)
    {
        subjectTrambolineForceEffect = subjectForce;
    }
    
    public IEnumerator FindFallSpeed() 
    {
        while (isInAir) 
        {
            if (subjectRigidbody2D.velocity.y < _fallSpeed) 
            {
                _fallSpeed = subjectRigidbody2D.velocity.y;
            }

            if (_fallSpeed < _landLimit) 
            {
                subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.FALL);
                yield break;
            }

            yield return null;
        }
    }
}
