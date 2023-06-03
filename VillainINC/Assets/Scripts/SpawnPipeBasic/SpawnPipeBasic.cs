using Munkur;
using TMPro;
using UnityEngine;

public class SpawnPipeBasic : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int totalSpawnAmount;
    public int TotalSpawnAmount => totalSpawnAmount;

    [SerializeField] private TMP_Text subjectAmountText;
    
    public bool IsAllSubjectSpawned { get; set; } = false;

    private void Awake()
    {
        LevelFlowManager.Instance.OnStartGame += OnStartGame;
        subjectAmountText.text = totalSpawnAmount.ToString();
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
            AudioManager.Instance.PlaySoundEffect("Spawn");
            SubjectBasic spawnedSubjectBasic = Instantiate(DataSOManager.Instance.GameDataSO
                .SubjectBasicList[PlayerPrefs.GetInt("SELECTED_SUBJECT", 0)], spawnPoint.position, Quaternion.identity);
            spawnedSubjectBasic.Init(this);
            totalSpawnAmount--;
            subjectAmountText.text = totalSpawnAmount.ToString();
        }
        else
        {
            IsAllSubjectSpawned = true;
            LevelFlowManager.Instance.ExecuteSuccessPriorities();
        }
    }
}
