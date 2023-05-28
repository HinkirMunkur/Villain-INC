using UnityEngine;
using TMPro;

public class StoreUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text cardAmountText;
    [SerializeField] private StoreUIExitButton storeUIExitButton;
    
    private const string CARD_AMOUNT = "CARD_AMOUNT";
    
    public void InitStoreUI()
    {
        storeUIExitButton.SubsClickable();
        cardAmountText.text = GetCardAmount().ToString();
    }

    private int GetCardAmount()
    {
        return PlayerPrefs.GetInt(CARD_AMOUNT, 0);
    }

    private void SetCardAmount(int cardAmount)
    {
        PlayerPrefs.SetInt(CARD_AMOUNT, cardAmount);
    }


}
