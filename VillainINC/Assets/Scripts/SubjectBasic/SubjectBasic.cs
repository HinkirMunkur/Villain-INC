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
}
