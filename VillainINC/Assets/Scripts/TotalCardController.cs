using UnityEngine;

public class TotalCardController : MonoBehaviour
{
    [SerializeField] private CardBasic _cardBasic;
    private const string CARD_AMOUNT = "CARD_AMOUNT";

    private int amount;

    private void Awake() 
    {
        _cardBasic.PickupBehaviour.OnCardPickup += Increment;

        amount = PlayerPrefs.GetInt(CARD_AMOUNT, 0);
    }

    private void OnDestroy() 
    {
        _cardBasic.PickupBehaviour.OnCardPickup -= Increment;    
    }

    private void Increment() 
    {
        amount++;
        PlayerPrefs.SetInt(CARD_AMOUNT, amount);
    }  
}
