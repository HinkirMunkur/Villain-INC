using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectDieBehaviour : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    
    public void PlayerDie()
    {
        Destroy(subjectBasic.gameObject);
    }
}
