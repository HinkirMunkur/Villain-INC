using UnityEngine;

public class SubjectBasic : MonoBehaviour, IAmBasic
{
    [SerializeField] private MovementBehaviour movementBehaviour;
    public MovementBehaviour MovementBehaviour => movementBehaviour;
    
    [SerializeField] private SubjectAnimationController subjectAnimationController;
    public SubjectAnimationController SubjectAnimationController => subjectAnimationController;

    [SerializeField] private SubjectStateMachineController subjectStateMachineController;
    public SubjectStateMachineController SubjectStateMachineController => subjectStateMachineController;

    [SerializeField] private HandTriggerHandler handTriggerHandler;
    public HandTriggerHandler HandTriggerHandler => handTriggerHandler;

    [SerializeField] private SubjectDieBehaviour subjectDieBehaviour;
    public SubjectDieBehaviour SubjectDieBehaviour => subjectDieBehaviour;

    [SerializeField] private SubjectAudio subjectAudio;
    public SubjectAudio SubjectAudio => subjectAudio;

    private SpawnPipeBasic spawnPipeBasic;

    public SpawnPipeBasic SpawnPipeBasic => spawnPipeBasic;
    public void Init(SpawnPipeBasic spawnPipeBasic)
    {
        this.spawnPipeBasic = spawnPipeBasic;
    }
}
