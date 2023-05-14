using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTriggerHandler : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Ground"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.RUN);
        }
        else if (col.tag.Equals("Tramboline"))
        {
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.JUMP);
        }
    }
}
