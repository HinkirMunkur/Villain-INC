using UnityEngine;

public class SpawnPipeBasic : MonoBehaviour
{
    [SerializeField] private SubjectBasic subjectBasicPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int totalSpawnAmount;

    public int TotalSpawnAmount => totalSpawnAmount;

    private void Awake()
    {
        LevelFlowManager.Instance.OnStartGame += OnStartGame;
    }

    private void OnDestroy()
    {
        if (LevelFlowManager.Instance != null)
        {
            LevelFlowManager.Instance.OnStartGame -= OnStartGame;
        }
    }

    private void OnStartGame()
    {
        SpawnSubjectBasic();
    }
    
    public void SpawnSubjectBasic()
    {
        if (totalSpawnAmount > 0)
        {
            SubjectBasic spawnedSubjectBasic = Instantiate(subjectBasicPrefab, spawnPoint);
            spawnedSubjectBasic.Init(this);
            totalSpawnAmount--;
        }
        else
        {
            LevelFlowManager.Instance.ExecuteSuccessPriorities();
        }
    }
}
