using TMPro;
using UnityEngine;

public class TapToLaunchColliderHandler : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Clickable clickable;
    [SerializeField] private LevelFlowManager levelFlowManager;
    [SerializeField] private TMP_Text tapToLaunchText;
    
    private void Start()
    {
        clickable.OnClicked += OnClicked;
    }

    private void OnDestroy()
    {
        clickable.OnClicked -= OnClicked;
    }

    private void OnClicked()
    {
        tapToLaunchText.gameObject.SetActive(false);
        levelFlowManager.StartGame();
        gameObject.SetActive(false);
        boxCollider.enabled = false;
    }
    
}
