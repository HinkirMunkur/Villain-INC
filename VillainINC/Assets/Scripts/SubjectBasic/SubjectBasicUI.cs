using UnityEngine;

public class SubjectBasicUI : MonoBehaviour
{
    [SerializeField] private int _skinCost;
    public int SkinCost => _skinCost;

    [SerializeField] private string SUBJECT_KEY;
    
     public string SUBJECT_KEY_PROP => SUBJECT_KEY;
    
    public bool TryToBuySubject()
    {
        if(_skinCost > StoreUIController.Instance.GetCardAmount())
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt(SUBJECT_KEY, 1);
            StoreUIController.Instance.SetCardAmount(StoreUIController.Instance.GetCardAmount()-_skinCost);
            StoreUIController.Instance.UpdateCardAmountText();
            return true;
        }
    }

    public int GetSkinData()
    {
        return PlayerPrefs.GetInt(SUBJECT_KEY, 0);
    }
    
}
