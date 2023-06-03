using UnityEngine.EventSystems;
using Munkur;

public class RestartImageActivity : ImageActivity
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySoundEffect("Restart");
        LevelController.Instance.LoadCurrLevel();
    }
}
