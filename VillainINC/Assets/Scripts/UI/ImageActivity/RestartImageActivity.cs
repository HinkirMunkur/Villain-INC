using UnityEngine.EventSystems;

public class RestartImageActivity : ImageActivity
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        LevelController.Instance.LoadCurrLevel();
    }
}
