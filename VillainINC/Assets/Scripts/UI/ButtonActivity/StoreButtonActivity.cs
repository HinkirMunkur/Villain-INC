using UnityEngine.EventSystems;
using UnityEngine;
using Munkur;

public class StoreButtonActivity : ButtonActivity
{
    [SerializeField] private int storeLevelIndex;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        LevelController.Instance.LoadLevelWithIndex(storeLevelIndex);
    }
}
