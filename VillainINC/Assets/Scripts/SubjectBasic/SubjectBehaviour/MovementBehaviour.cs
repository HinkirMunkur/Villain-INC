using System.Collections;
using UnityEngine;
using System;
using Munkur;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;

    [SerializeField] private float runSpeed;
    [SerializeField] private float pushSpeed;
    
    [SerializeField] private Rigidbody2D subjectRigidbody2D;
    public Rigidbody2D SubjectRigidbody2D => subjectRigidbody2D;

    private bool isInAir;

    public bool IsInAir
    {
        get { return isInAir; }
        set { isInAir = value; }
    }

    private bool isInGround = false;

    public bool IsInGround
    {
        get { return isInAir; }
        set { isInAir = value; }
    }
    
    private float fallSpeed;
    public float FallSpeed 
    {
        set { fallSpeed = value; }
    }
    private float landLimit = -3f;

    private Vector2 subjectRunVelocity;
    private Vector2 subjectPushItemVelocity;
    private Vector2 subjectTrambolineForceEffect;
    
    private void Awake()
    {
        subjectRunVelocity = new Vector2(runSpeed, 0);
        subjectPushItemVelocity = new Vector2(pushSpeed, 0);
        subjectTrambolineForceEffect = new Vector2(Math.Sign(subjectRunVelocity.x) * 2, 4);
    }

    public void RunSteady()
    {
        StartCoroutine(RunSteadyRoutine());
    }
    
    private IEnumerator RunSteadyRoutine()
    {
        while (subjectBasic.SubjectStateMachineController.GetCurrentState() == ESubjectState.RUN)
        {
            
            subjectRigidbody2D.velocity = (subjectRigidbody2D.velocity * Vector2.up) + subjectRunVelocity;
            yield return null;
        }
    }

    public void PushSteady()
    {
        StartCoroutine(PushSteadyRoutine());
    }
    
    private IEnumerator PushSteadyRoutine()
    {
        while (subjectBasic.SubjectStateMachineController.GetCurrentState() == ESubjectState.PUSH)
        {
            subjectRigidbody2D.velocity = (subjectRigidbody2D.velocity * Vector2.up) + subjectPushItemVelocity;
            yield return null;
        }
    }

    public void ChangeVelocity(Vector2 subjectVelocity)
    {
        subjectRigidbody2D.velocity = subjectVelocity;
    }

    public void RotateSubject()
    {
        subjectRunVelocity = (Vector2.left + Vector2.up) * subjectRunVelocity;
        subjectPushItemVelocity = (Vector2.left + Vector2.up) * subjectPushItemVelocity;
        subjectBasic.transform.Rotate(0, 180, 0);
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
        Debug.Log(isInAir);
        while (isInAir) 
        {
            if (subjectRigidbody2D.velocity.y < fallSpeed) 
            {
                fallSpeed = subjectRigidbody2D.velocity.y;
            }

            if (fallSpeed < landLimit) 
            {
                subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.FALL);
                yield break;
            }

            yield return null;
        }
    }
}
