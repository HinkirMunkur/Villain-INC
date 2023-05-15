using UnityEngine;

public class PortalTriggerHandler : MonoBehaviour
{
    [SerializeField] private PortalBasic _portalBasic;
    private bool _enteredFromThisPortal = false;
    public bool EnteredFromThisPortal
    {
        get { return _enteredFromThisPortal; }
        set { _enteredFromThisPortal = value; }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (!_portalBasic.OtherPortal.PortalTriggerHandler.EnteredFromThisPortal) 
        {
            if (col.CompareTag("Player")) 
            {
                _enteredFromThisPortal = true;
                _portalBasic.TeleportBehaviour.Teleport(col);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _portalBasic.OtherPortal.PortalTriggerHandler.EnteredFromThisPortal = false;
    }
}
