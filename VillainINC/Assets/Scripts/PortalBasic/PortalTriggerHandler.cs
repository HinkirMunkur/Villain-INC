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
        if (col.CompareTag("Player") || col.CompareTag("PushBox") || col.CompareTag("Wall")) 
        {
            if (!_portalBasic.OtherPortal.PortalTriggerHandler.EnteredFromThisPortal) 
            {
                _enteredFromThisPortal = true;
                _portalBasic.TeleportBehaviour.Teleport(col);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("PushBox") || col.CompareTag("Wall")) 
        {
            _portalBasic.OtherPortal.PortalTriggerHandler.EnteredFromThisPortal = false;
        }
    }
}
