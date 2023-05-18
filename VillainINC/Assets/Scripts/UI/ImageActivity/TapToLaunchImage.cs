using UnityEngine;
using UnityEngine.EventSystems;

public class TapToLaunchImage : ImageActivity
{
    [SerializeField] private LevelFlowManager levelFlowManager;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        levelFlowManager.StartGame();
        Destroy(gameObject);
    }
}
