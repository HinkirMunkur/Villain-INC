using UnityEngine.EventSystems;
using Munkur;
using UnityEngine;

public class RestartImageActivity : ImageActivity
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(LevelFlowManager.Instance.IsLevelFinished)
        {
            return;
        }

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        AudioManager.Instance.PlaySoundEffect("Restart");
        LevelController.Instance.LoadCurrLevel();
    }
}
