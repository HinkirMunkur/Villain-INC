using UnityEngine;
using TMPro;

public class StoreUIController : Singletonn<StoreUIController>
{
    [SerializeField] private TMP_Text cardAmountText;
    [SerializeField] private StoreUIExitButton storeUIExitButton;
    [SerializeField] private SubjectUIController subjectUIController;
    
    private const string CARD_AMOUNT = "CARD_AMOUNT";
    
    public void InitStoreUI()
    {
        subjectUIController.InitSubjectUIController();
        
        storeUIExitButton.SubsClickable();
        cardAmountText.text = GetCardAmount().ToString();
    }

    public void CloseStoreUI()
    {
        subjectUIController.CloseSubjectUIController();
    }

    public int GetCardAmount()
    {
        return PlayerPrefs.GetInt(CARD_AMOUNT, 0);
    }

    public void SetCardAmount(int cardAmount)
    {
        PlayerPrefs.SetInt(CARD_AMOUNT, cardAmount);
    }

    public void UpdateCardAmountText()
    {
        cardAmountText.text = GetCardAmount().ToString();
    }
}
