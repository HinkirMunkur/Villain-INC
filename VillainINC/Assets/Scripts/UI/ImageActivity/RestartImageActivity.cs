using UnityEngine.EventSystems;
using Munkur;
using UnityEngine;

public class RestartImageActivity : ImageActivity
{
    public static bool IsRestart;
    
    private void Start()
    {
        IsRestart = false;
    }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(LevelFlowManager.Instance.IsLevelFinished || BackToMenuImageActivity.IsBackMenu)
        {
            return;
        }

        IsRestart = true;
        image.raycastTarget = false;
        
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        AudioManager.Instance.PlaySoundEffect("Restart");
        LevelController.Instance.LoadCurrLevel();
    }
}
