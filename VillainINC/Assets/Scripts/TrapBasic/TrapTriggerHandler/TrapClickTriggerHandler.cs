using UnityEngine;

public class TrapClickTriggerHandler : MonoBehaviour
{
    [SerializeField] private ClickableTrapBasic clickableTrapBasic;
    [SerializeField] private Clickable clickable;

    private void Awake()
    {
        clickable.OnClicked += OnClicked;
    }

    private void OnDestroy()
    {
        clickable.OnClicked -= OnClicked;
    }

    private void OnClicked()
    {
        clickableTrapBasic.TrapClicked();
        
        if (clickable.OneTime)
        {
            clickable.OnClicked -= OnClicked;
        }
    }
}
