using Munkur;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackToMenuImageActivity : ImageActivity
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

        AudioManager.Instance.PlaySoundEffect("Back");
        LevelController.Instance.LoadLevelWithIndex(1);
    }
}
