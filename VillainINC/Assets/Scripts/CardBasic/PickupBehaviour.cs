using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] private CardBasic _cardBasic;
    public Action OnCardPickup;

    public void Pickup() 
    {
        OnCardPickup?.Invoke();
        _cardBasic.gameObject.SetActive(false);
        PlayerPrefs.SetInt(_cardBasic.CardName, 0);
    }
}
