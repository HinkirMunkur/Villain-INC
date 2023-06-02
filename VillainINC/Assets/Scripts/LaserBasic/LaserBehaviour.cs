using System.Collections;
using UnityEngine;
using System;
using Munkur;
using UnityEngine.Serialization;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private LaserBasic _laserBasic;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private Transform _laserFirePoint;
    [SerializeField] private LineRenderer _laserLineRenderer;
    //[SerializeField] private ParticleSystem _laserStartParticleSystem;
    //[SerializeField] private GameObject _laserEndParticleSystem;
    [SerializeField] private GameObject _laserStart;
    [SerializeField] private GameObject _laserEnd;

    [SerializeField] private LayerMask laserHitLayer;

    private bool isLaserShotFinished = true;
    private Coroutine stopRoutine;
    
    private void Start() 
    {
        _laserStart.SetActive(false);
        _laserEnd.SetActive(false);
        _laserLineRenderer.gameObject.SetActive(false);
        if (_laserBasic.AlwaysShoot) 
        {
            StartCoroutine(AlwaysShootLaser());
        }
    }
    
    public void ShootLaserCoroutine()
    {
        if (isLaserShotFinished)
        {
            isLaserShotFinished = false;
            _laserStart.SetActive(true);
            _laserEnd.SetActive(true);
            _laserLineRenderer.gameObject.SetActive(true);
            stopRoutine = StartCoroutine(ShootLaser());
        }
    }
    
    public void StopShootLaserCoroutine()
    {
        if (!isLaserShotFinished)
        {
            isLaserShotFinished = true;
            _laserStart.SetActive(false);
            _laserEnd.SetActive(false);
            _laserLineRenderer.gameObject.SetActive(false);
            StopCoroutine(stopRoutine);
        }
    }
    private IEnumerator ShootLaser()
    {
        AudioManager.Instance.PlaySoundEffect("Laser");
        _laserLineRenderer.gameObject.SetActive(true);
        _laserStart.SetActive(true);
        _laserEnd.SetActive(true);
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(_laserFirePoint.position, transform.right);

            while (hit && hit.collider.CompareTag("Wind")) 
            {
                hit = Physics2D.Raycast(hit.point + (Vector2)transform.right, transform.right);
            }
            
            if (hit) 
            {
                if (hit.collider.CompareTag("Player"))
                {
                    _laserBasic.Slay(hit.transform.GetComponent<SubjectBasic>());
                }

                _laserEnd.transform.position = hit.point;
                Draw2DRay(_laserFirePoint.position, hit.point);
            }
            else 
            {
                _laserEnd.transform.position = hit.point;
                Draw2DRay(_laserFirePoint.position, _laserFirePoint.position + transform.right * _rayDistance);
            }

            yield return null;
        }
    }
    
    private IEnumerator AlwaysShootLaser()
    {
        AudioManager.Instance.PlaySoundEffect("Laser");
        _laserLineRenderer.gameObject.SetActive(true);
        _laserStart.SetActive(true);
        _laserEnd.SetActive(true);
        while (_laserBasic.AlwaysShoot)
        {
            RaycastHit2D hit = Physics2D.Raycast(_laserFirePoint.position, transform.right);

            while (hit && hit.collider.CompareTag("Wind")) 
            {
                hit = Physics2D.Raycast(hit.point + (Vector2)transform.right, transform.right);
            }

            if (hit) 
            {
                if (hit.collider.CompareTag("Player"))
                {
                    _laserBasic.Slay(hit.transform.GetComponent<SubjectBasic>());
                }

                _laserEnd.transform.position = hit.point;
                Draw2DRay(_laserFirePoint.position, hit.point);
            }
            else 
            {
                _laserEnd.transform.position = hit.point;
                Draw2DRay(_laserFirePoint.position, _laserFirePoint.position + transform.right * _rayDistance);
            }

            yield return null;
        }

        Draw2DRay(Vector2.zero, Vector2.zero);   
    }
    
    private void Draw2DRay(Vector2 startVector, Vector2 endVector) 
    {
        _laserLineRenderer.SetPosition(0, startVector);
        _laserLineRenderer.SetPosition(1, endVector);
    }
}
