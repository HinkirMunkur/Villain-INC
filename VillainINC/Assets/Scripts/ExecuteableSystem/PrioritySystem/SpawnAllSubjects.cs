using UnityEngine;

public class SpawnAllSubjects : Priority
{
    [SerializeField] private SpawnPipeBasic spawnPipeBasic;
    
    public override ETaskStatus Run()
    {
        CurrentTaskSuccess = (spawnPipeBasic.TotalSpawnAmount == 0);
        return ETaskStatus.FINISH;
    }
}
