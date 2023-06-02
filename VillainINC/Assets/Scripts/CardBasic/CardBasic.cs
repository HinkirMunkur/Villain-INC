using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBasic : MonoBehaviour
{
    [SerializeField] private string _cardName;
    public string CardName => _cardName;

    [SerializeField] private PickupBehaviour _pickupBehaviour;
    public PickupBehaviour PickupBehaviour => _pickupBehaviour;

    [SerializeField] private PickupTriggerHandler _pickupTriggerHandler;
    public PickupTriggerHandler PickupTriggerHandler => _pickupTriggerHandler;

    private void Awake() 
    {
        bool isTaken = Convert.ToBoolean(PlayerPrefs.GetInt(_cardName, 1));

        gameObject.SetActive(isTaken);    
    }
}
