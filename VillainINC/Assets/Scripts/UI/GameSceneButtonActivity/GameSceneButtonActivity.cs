using UnityEngine.UI;
using UnityEngine;
using Munkur;

[RequireComponent(typeof(Button))]
public class GameSceneButtonActivity : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Awake()
    {
        MouseInputSystemManager.Instance.OnMouseLeftClicked += OnButtonClicked;
    }

    private void OnDestroy()
    {
        MouseInputSystemManager.Instance.OnMouseLeftClicked -= OnButtonClicked;
    }

    public void DeactivateButton()
    {
        button.interactable = false;
    }

    public void ActivateButton()
    {
        button.interactable = true;
    }

    protected virtual void OnButtonClicked(Vector2 delta)
    {
        
    }
}
