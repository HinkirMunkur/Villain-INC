using UnityEngine;

public class PortalBasic : MonoBehaviour, IAmBasic
{
    [SerializeField] private TeleportBehaviour _teleportBehaviour;
    public TeleportBehaviour TeleportBehaviour => _teleportBehaviour;
    [SerializeField] private PortalTriggerHandler _portalTriggerHandler;
    public PortalTriggerHandler PortalTriggerHandler => _portalTriggerHandler;
    [SerializeField] private PortalBasic _otherPortal;
    public PortalBasic OtherPortal => _otherPortal;
    [SerializeField] private Transform _teleportPoint;
    public Transform TeleportPoint => _teleportPoint;
}
