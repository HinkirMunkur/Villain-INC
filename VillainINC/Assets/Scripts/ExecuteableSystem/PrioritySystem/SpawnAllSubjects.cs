using UnityEngine;

public class SpawnAllSubjects : Priority
{
    [SerializeField] private SpawnPipeBasic spawnPipeBasic;
    
    public override ETaskStatus Run()
    {
        CurrentTaskSuccess = spawnPipeBasic.IsAllSubjectSpawned;
        return ETaskStatus.FINISH;
    }
}
