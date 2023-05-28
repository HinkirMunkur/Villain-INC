using UnityEngine;

public class StoreUIExitButton : MonoBehaviour
{
    [SerializeField] private StoreGameSceneButtonActivity storeGameSceneButtonActivity;
    [SerializeField] private Transform storeUI;
    [SerializeField] private Clickable clickable;

    public void SubsClickable()
    {
        clickable.OnClicked += OnExitButtonClicked;
    }

    public void UnSubsClickable()
    {
        clickable.OnClicked -= OnExitButtonClicked;
    }

    private void OnExitButtonClicked()
    {
        storeGameSceneButtonActivity.CloseStoreUI();
        storeUI.gameObject.SetActive(false);
        UnSubsClickable();
    }
    
}
