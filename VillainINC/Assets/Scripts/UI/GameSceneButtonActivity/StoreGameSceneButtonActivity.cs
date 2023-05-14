using UnityEngine;

public class StoreGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private int storeFirstLevelIndex;
    protected override void OnButtonClicked(Vector2 delta)
    {
        LevelController.Instance.LoadLevelWithIndex(storeFirstLevelIndex);
    }
}
