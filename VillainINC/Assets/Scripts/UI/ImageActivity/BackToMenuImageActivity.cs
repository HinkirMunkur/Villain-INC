using System;
using Munkur;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackToMenuImageActivity : ImageActivity
{
    public static bool IsBackMenu;

    private void Start()
    {
        IsBackMenu = false;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(LevelFlowManager.Instance.IsLevelFinished || RestartImageActivity.IsRestart)
        {
            return;
        }
        
        IsBackMenu = true;
        image.raycastTarget = false;
        
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        AudioManager.Instance.PlaySoundEffect("Back");
        AudioManager.Instance.StopMusic();
        TransitionManager.Instance.EndSceneTransition(LevelController.Instance.GetSceneNameWithIndex(1));
    }
}
