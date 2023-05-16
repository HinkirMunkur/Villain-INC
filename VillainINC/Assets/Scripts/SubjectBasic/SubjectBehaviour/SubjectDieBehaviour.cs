using UnityEngine;

public class SubjectDieBehaviour : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasic;
    
    public void SubjectDie()
    {
        Destroy(subjectBasic.gameObject);
    }
}
