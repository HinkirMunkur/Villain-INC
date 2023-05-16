using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private LaserBasic _laserBasic;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private float _laserDuration = 3f;
    [SerializeField] private Transform _laserFirePoint;
    [SerializeField] private LineRenderer _laserLineRenderer;
    
    private void Awake() 
    {
        _laserBasic.LaserClick.OnClicked += ShootLaserCoroutine;    
    }

    private void OnDestroy() 
    {
        _laserBasic.LaserClick.OnClicked -= ShootLaserCoroutine;    
    }

    private void ShootLaserCoroutine()
    {
        StartCoroutine(ShootLaser());
    }
    private IEnumerator ShootLaser()
    {
        float duration = 0;
        while (duration < _laserDuration)
        {
            Vector2 lastPointHit = transform.right;
            List<Vector2> vectors = new List<Vector2>();
            vectors.Add(_laserFirePoint.position);

            RaycastHit2D hit = Physics2D.Raycast(_laserFirePoint.position, transform.right);
            while (hit)
            {
                vectors.Add(hit.point);

                if (hit.collider.gameObject.CompareTag("Portal"))
                {
                    PortalBasic portalBasic = hit.collider.gameObject.GetComponentInParent<PortalBasic>();
                    vectors.Add(portalBasic.OtherPortal.TeleportLaserRight.position);
                    lastPointHit = portalBasic.OtherPortal.TeleportLaserRight.position;

                    hit = Physics2D.Raycast(portalBasic.OtherPortal.TeleportLaserRight.position, transform.right);
                    
                }
                else 
                {
                    break;
                }
            }

            if (hit) 
            {
                Draw2DRay(vectors.ToArray());
            }
            else 
            {
                vectors.Add(lastPointHit + (Vector2)transform.right * _rayDistance);
                Draw2DRay(vectors.ToArray());
            }

            duration += Time.deltaTime;
            yield return null;
        }

        Draw2DRay(Vector2.zero, Vector2.zero);   
    }


    private void Draw2DRay(params Vector2[] positions) 
    {
        _laserLineRenderer.positionCount = positions.Length;
        for (int i = 0; i < positions.Length; i++) 
        {
            _laserLineRenderer.SetPosition(i, positions[i]);
        }
    }
}
