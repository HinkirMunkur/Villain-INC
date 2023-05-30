using Munkur;
using UnityEngine;

public class SpawnPipeBasic : MonoBehaviour
{
    //[SerializeField] private SubjectBasic subjectBasicPrefab;
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
            SubjectBasic spawnedSubjectBasic = Instantiate(DataSOManager.Instance.GameDataSO
                .SubjectBasicList[PlayerPrefs.GetInt("SELECTED_SUBJECT", 0)], spawnPoint.position, Quaternion.identity);
            spawnedSubjectBasic.Init(this);
            totalSpawnAmount--;
        }
        else
        {
            LevelFlowManager.Instance.ExecuteSuccessPriorities();
        }
    }
}
