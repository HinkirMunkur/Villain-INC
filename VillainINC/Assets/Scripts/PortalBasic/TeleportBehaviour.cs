using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    [SerializeField] private PortalBasic _portalBasic;
    public void Teleport(Collider2D col) 
    {
        col.transform.position = _portalBasic.OtherPortal.TeleportPoint.position;
    }
}
