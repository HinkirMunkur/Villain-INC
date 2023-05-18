using System.Collections;
using UnityEngine;
using System;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private LaserBasic _laserBasic;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private float _laserDuration = 3f;
    [SerializeField] private Transform _laserFirePoint;
    [SerializeField] private LineRenderer _laserLineRenderer;

    [SerializeField] private LayerMask laserHitLayer;

    private bool isLaserShotFinished = true;
    
    private void Start() 
    {
        if (_laserBasic.AlwaysShoot) 
        {
            _laserBasic.LaserClick.enabled = false;
            StartCoroutine(ShootLaser());
        }
    }
    
    public void ShootLaserCoroutine()
    {
        if (isLaserShotFinished)
        {
            isLaserShotFinished = false;
            StartCoroutine(ShootLaser(() => isLaserShotFinished = true));
        }
    }
    private IEnumerator ShootLaser(Action OnLaserShotFinished = null)
    {
        float duration = 0;
        
        while (duration < _laserDuration || _laserBasic.AlwaysShoot)
        {
            RaycastHit2D hit = Physics2D.Raycast(_laserFirePoint.position, transform.right);

            if (hit) 
            {
                if (hit.collider.CompareTag("Player"))
                {
                    _laserBasic.Slay(hit.transform.GetComponent<SubjectBasic>());
                }
                
                Draw2DRay(_laserFirePoint.position, hit.point);
            }
            else 
            {
                Draw2DRay(_laserFirePoint.position, _laserFirePoint.position + transform.right * _rayDistance);
            }

            duration += Time.deltaTime;
            yield return null;
        }

        Draw2DRay(Vector2.zero, Vector2.zero);   
        OnLaserShotFinished?.Invoke();
    }
    
    private void Draw2DRay(Vector2 startVector, Vector2 endVector) 
    {
        _laserLineRenderer.SetPosition(0, startVector);
        _laserLineRenderer.SetPosition(1, endVector);
    }
}
