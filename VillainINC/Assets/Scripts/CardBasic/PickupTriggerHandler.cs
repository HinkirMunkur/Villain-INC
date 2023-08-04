using UnityEngine;

public class PickupTriggerHandler : MonoBehaviour
{
    [SerializeField] private CardBasic _cardBasic;
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            _cardBasic.PickupBehaviour.Pickup();
        }
    }
}
