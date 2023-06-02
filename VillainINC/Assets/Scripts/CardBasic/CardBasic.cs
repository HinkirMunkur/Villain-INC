using System;
using DG.Tweening;
using UnityEngine;

public class CardBasic : MonoBehaviour
{
    [SerializeField] private string _cardName;
    public string CardName => _cardName;

    [SerializeField] private PickupBehaviour _pickupBehaviour;
    public PickupBehaviour PickupBehaviour => _pickupBehaviour;

    [SerializeField] private PickupTriggerHandler _pickupTriggerHandler;
    public PickupTriggerHandler PickupTriggerHandler => _pickupTriggerHandler;

    [SerializeField] private float shakeDuration;
    
    private void Awake() 
    {
        bool isTaken = Convert.ToBoolean(PlayerPrefs.GetInt(_cardName, 1));

        gameObject.SetActive(isTaken);    
    }

    private void Start()
    {
        CardShake();
    }

    private void CardShake()
    {
        transform.DOShakePosition(shakeDuration, 0.01f, 1, 0f).SetLoops(-1);
    }
}
