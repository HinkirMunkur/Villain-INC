using UnityEngine;
using System;
using Munkur;

public class Clickable : MonoBehaviour
{
    [SerializeField] private Camera rayCamera;
    [SerializeField] private LayerMask layer;
    
    public Action OnClicked;

    private RaycastHit2D ray;
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
        ray = Physics2D.Raycast(rayCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 
            Mathf.Infinity, layer);
        
        Debug.DrawRay(rayCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Color.red);
        
        if (ray.collider != null && ray.collider.gameObject == gameObject) 
        {
            OnClicked?.Invoke();
        }
    }
}
