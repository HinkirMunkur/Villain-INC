using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToLaunchImage : ImageActivity
{
    [SerializeField] private LevelFlowManager levelFlowManager;
    [SerializeField] private TMP_Text tapToImageText;
        
    public override void OnPointerClick(PointerEventData eventData)
    {
        levelFlowManager.StartGame();
        gameObject.SetActive(false);
        tapToImageText.gameObject.SetActive(false);
    }
}
