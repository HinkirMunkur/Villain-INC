using UnityEngine;
using Munkur;

public class StartGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private int startFirstLevelIndex;
    protected override void Clicked()
    {
        LevelController.Instance.LoadLevelWithIndex(startFirstLevelIndex);
        AudioManager.Instance.StopMusic();
    }
}
