using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTriggerHandler : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Box"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.PUSH);
        }
        // else if (col.CompareTag("Untagged"))
        // {
        //     subjectBasic.transform.Rotate(0, 180, 0);
        //     subjectBasic.MovementBehaviour.RotateSubject();
        // }
    }
}
