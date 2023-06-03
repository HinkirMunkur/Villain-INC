using Munkur;
public class StartGameSceneButtonActivity : GameSceneButtonActivity
{
    protected override void Clicked()
    {
        AudioManager.Instance.PlaySoundEffect("Click");
        AudioManager.Instance.StopMusic();
        LevelController.Instance.LoadLevelWithIndex(LevelController.Instance.GetCurrentSavedLevelIndex());
    }
}
