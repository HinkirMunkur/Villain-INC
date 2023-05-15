using UnityEngine;

public class StoreGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private int storeFirstLevelIndex;
    
    protected override void Clicked()
    {
        LevelController.Instance.LoadLevelWithIndex(storeFirstLevelIndex);
    }
}
