using UnityEngine;
using Munkur;

public abstract class GameSceneButtonActivity : MonoBehaviour
{
    [SerializeField] private Camera rayCamera;
    [SerializeField] private LayerMask layer;
    
    private void Awake()
    { 
        MouseInputSystemManager.Instance.OnMouseLeftClicked += OnMouseLeftClicked;
    }

    private void OnDestroy() 
    {
        MouseInputSystemManager.Instance.OnMouseLeftClicked -= OnMouseLeftClicked;    
    }

    protected virtual void OnMouseLeftClicked(Vector2 delta)
    {
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Clicked();
        }
        
    }

    protected abstract void Clicked();

}
