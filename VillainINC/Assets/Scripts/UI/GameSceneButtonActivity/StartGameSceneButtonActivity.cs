
public class StartGameSceneButtonActivity : GameSceneButtonActivity
{
    protected override void Clicked()
    {
        LevelController.Instance.LoadLevelWithIndex(LevelController.Instance.GetCurrentSavedLevelIndex());
    }
}
