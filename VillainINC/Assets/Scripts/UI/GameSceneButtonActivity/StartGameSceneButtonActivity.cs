using UnityEngine;

public class StartGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private int startFirstLevelIndex;
    
    protected override void OnButtonClicked(Vector2 delta)
    {
        LevelController.Instance.LoadLevelWithIndex(startFirstLevelIndex);
    }
}
