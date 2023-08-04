using System;
using UnityEngine;
using DG.Tweening;
using Munkur;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] private CardBasic _cardBasic;
    [SerializeField] private float disappearDuration;
    public Action OnCardPickup;

    public void Pickup()
    {
        AudioManager.Instance.PlaySoundEffect("Card");
        OnCardPickup?.Invoke();
        PlayerPrefs.SetInt(_cardBasic.CardName, 0);
        _cardBasic.transform.DOScale(Vector3.zero, disappearDuration).SetEase(Ease.InOutElastic).OnComplete(() =>
        {
            _cardBasic.gameObject.SetActive(false);
        });
    }
}
