using UnityEngine;
using EasyButtons;

public class TestObject : MonoBehaviour
{
    [SerializeField] private SubjectStateMachineController subjectStateMachineController;
    [SerializeField] private ESubjectState eSubjectState;

    [Button]
    private void ChangeSubjectStateTo()
    {
        subjectStateMachineController.DoTransition(eSubjectState);
    }
}
