using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTriggerHandler : MonoBehaviour
{
    [SerializeField] private CardBasic _cardBasic;
    private void OnTriggerEnter2D(Collider2D col) 
    {
        _cardBasic.PickupBehaviour.Pickup();
    }
}
