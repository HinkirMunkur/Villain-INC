using UnityEngine;
using System;
using Munkur;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    [SerializeField] private Camera rayCamera;
    [SerializeField] private LayerMask layer;

    [SerializeField] private bool oneTime;
    
    public bool OneTime => oneTime;
    
    public Action OnClicked;

    private RaycastHit2D raycastHit2D;
    private Ray ray;
    
    private void Awake()
    { 
        MouseInputSystemManager.Instance.OnMouseLeftClicked += OnClick;
    }

    private void OnDestroy() 
    {
        MouseInputSystemManager.Instance.OnMouseLeftClicked -= OnClick;    
    }

    public virtual void OnClick(Vector2 mousePosition) 
    {
        ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        raycastHit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layer);
        
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject == gameObject)
        {
            if (StaticUtilitiesBase.IsPointerOverUIObject())
            {
                return;
            }
            
            OnClicked?.Invoke();

            if (oneTime)
            {
                MouseInputSystemManager.Instance.OnMouseLeftClicked -= OnClick; 
            }
        }
    }
}
