using UnityEngine;
using TMPro;

public class StoreUIController : MonoBehaviour
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
        subjectUIController.UnsubsClickable();
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
