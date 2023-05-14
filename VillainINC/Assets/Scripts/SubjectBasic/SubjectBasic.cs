using System;
using System.Collections;
using System.Collections.Generic;
using Munkur;
using UnityEngine;

public class SubjectBasic : MonoBehaviour
{
    [SerializeField] private MovementBehaviour movementBehaviour;
    public MovementBehaviour MovementBehaviour => movementBehaviour;
    
    [SerializeField] private SubjectAnimationController subjectAnimationController;
    public SubjectAnimationController SubjectAnimationController => subjectAnimationController;

    [SerializeField] private SubjectStateMachineController subjectStateMachineController;
    public SubjectStateMachineController SubjectStateMachineController => subjectStateMachineController;
}
