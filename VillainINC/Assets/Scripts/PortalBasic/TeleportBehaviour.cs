using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    [SerializeField] private PortalBasic _portalBasic;
    [SerializeField] private float _pushSpeed;
    [SerializeField] private ParticleSystem _littleParticles;
    
    public void Teleport(Collider2D col) 
    {
        _littleParticles.Play(true);
        col.transform.position = _portalBasic.OtherPortal.TeleportPoint.position;

        if (!col.CompareTag("Player")) 
        {
            col.attachedRigidbody.AddForce(_portalBasic.OtherPortal.transform.right * col.transform.localScale.x * _pushSpeed);
        }
    }
}
