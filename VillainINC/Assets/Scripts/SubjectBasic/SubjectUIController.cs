using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Munkur;

public class SubjectUIController : MonoBehaviour
{
    [SerializeField] private List<SubjectBasicUI> subjectBasicUiList;

    [SerializeField] private Transform leftTransform;
    [SerializeField] private Transform centerTransform;
    [SerializeField] private Transform rightTransform;
    
    [SerializeField] private Clickable leftClickable;
    [SerializeField] private Clickable rightClickable;
    [SerializeField] private Clickable buyClickable;

    [SerializeField] private float moveDuration;

    [SerializeField] private float shakeButtonDuration;
    [SerializeField] private Vector3 shakeButtonStrength;

    [SerializeField] private TMP_Text purchaseText;
    [SerializeField] private TMP_Text cardAmountText;

    private const string x = "x";
    
    private const string SELECTED_SUBJECT = "SELECTED_SUBJECT";

    private int selectedSubjectIndex = 0;

    private int currentUsedSkinIndex = 0;
    
    public void InitSubjectUIController()
    {
        selectedSubjectIndex = PlayerPrefs.GetInt(SELECTED_SUBJECT, 0);

        if (selectedSubjectIndex == 0)
        {
            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex + 1].transform.position = rightTransform.position;
            subjectBasicUiList[selectedSubjectIndex + 1].transform.localScale = Vector3.one * 2; 
        }
        else if (selectedSubjectIndex == subjectBasicUiList.Count - 1)
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex - 1].transform.position = leftTransform.position;
            subjectBasicUiList[selectedSubjectIndex - 1].transform.localScale = Vector3.one * 2; 
        }
        else
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex - 1].transform.position = leftTransform.position;
            subjectBasicUiList[selectedSubjectIndex - 1].transform.localScale = Vector3.one * 2; 

            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex + 1].transform.position = rightTransform.position;
            subjectBasicUiList[selectedSubjectIndex + 1].transform.localScale = Vector3.one * 2; 
        }
        
        subjectBasicUiList[selectedSubjectIndex].gameObject.SetActive(true);
        subjectBasicUiList[selectedSubjectIndex].transform.position = centerTransform.position;
        subjectBasicUiList[selectedSubjectIndex].transform.localScale = Vector3.one * 4; 
        
        UpdateBuyButton(selectedSubjectIndex);
        SubsClickable();
    }

    public void CloseSubjectUIController()
    {
        AudioManager.Instance.PlaySoundEffect("Back");

        if (selectedSubjectIndex == 0)
        {
            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(false);
        }
        else if (selectedSubjectIndex == subjectBasicUiList.Count - 1)
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(false);
        }
        else
        {
            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(false);
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(false);
        }

        subjectBasicUiList[selectedSubjectIndex].gameObject.SetActive(false);
        
        UnsubsClickable();
    }
    
    private void SubsClickable()
    {
        leftClickable.OnClicked += OnLeftButtonClicked;
        rightClickable.OnClicked += OnRightButtonClicked;
        buyClickable.OnClicked += OnBuyButtonClicked;
    }
    
    private void UnsubsClickable()
    {
        leftClickable.OnClicked -= OnLeftButtonClicked;
        rightClickable.OnClicked -= OnRightButtonClicked;
        buyClickable.OnClicked -= OnBuyButtonClicked;
    }

    private void OnLeftButtonClicked()
    {
        if (selectedSubjectIndex == 0)
        {
            AudioManager.Instance.PlaySoundEffect("No");
            leftClickable.transform.DOShakePosition(shakeButtonDuration, shakeButtonStrength);
            return;
        }

        AudioManager.Instance.PlaySoundEffect("Click");

        if (selectedSubjectIndex+1 <= subjectBasicUiList.Count - 1)
        {
            subjectBasicUiList[selectedSubjectIndex + 1].gameObject.SetActive(false);
        }

        subjectBasicUiList[selectedSubjectIndex].transform.DOMove(rightTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex].transform.localScale = Vector3.one * 2; 
        
        subjectBasicUiList[selectedSubjectIndex-1].transform.DOMove(centerTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex-1].transform.localScale = Vector3.one * 4;

        if (selectedSubjectIndex-2 >= 0)
        {
            subjectBasicUiList[selectedSubjectIndex - 2].transform.position = leftTransform.position;
            subjectBasicUiList[selectedSubjectIndex - 2].transform.localScale = Vector3.one * 2;
            subjectBasicUiList[selectedSubjectIndex - 2].gameObject.SetActive(true);
        }
        
        selectedSubjectIndex--;
        UpdateBuyButton(selectedSubjectIndex);
    }

    private void OnRightButtonClicked()
    {
        if (selectedSubjectIndex == subjectBasicUiList.Count - 1)
        {
            AudioManager.Instance.PlaySoundEffect("No");
            rightClickable.transform.DOShakePosition(shakeButtonDuration, shakeButtonStrength);
            return;
        }

        AudioManager.Instance.PlaySoundEffect("Click");

        subjectBasicUiList[selectedSubjectIndex + 1].transform.DOMove(centerTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex + 1].transform.localScale = Vector3.one * 4; 
        
        subjectBasicUiList[selectedSubjectIndex].transform.DOMove(leftTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex].transform.localScale = Vector3.one * 2; 

        if (selectedSubjectIndex != 0)
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(false);
        }

        if (selectedSubjectIndex + 2 <= subjectBasicUiList.Count - 1)
        {
            subjectBasicUiList[selectedSubjectIndex + 2].transform.position = rightTransform.position;
            subjectBasicUiList[selectedSubjectIndex + 2].transform.localScale = Vector3.one * 2; 
            subjectBasicUiList[selectedSubjectIndex + 2].gameObject.SetActive(true);
        }

        selectedSubjectIndex++;
        UpdateBuyButton(selectedSubjectIndex);
    }

    private void UpdateBuyButton(int subjectIndex)
    {
        int skinData = subjectBasicUiList[subjectIndex].GetSkinData();
        
        if(skinData == 0)
        {
            cardAmountText.transform.parent.gameObject.SetActive(true);
            cardAmountText.text = x + subjectBasicUiList[subjectIndex].SkinCost;
            purchaseText.gameObject.SetActive(false);
        }
        else if(skinData == 1)
        {
            cardAmountText.transform.parent.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
            purchaseText.text = "USE";
        }
        else if(skinData == 2)
        {
            cardAmountText.transform.parent.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
            purchaseText.text = "USED";
        }
    }

    private void OnBuyButtonClicked()
    {
        int skinData = subjectBasicUiList[selectedSubjectIndex].GetSkinData();
        
        if(skinData == 0)
        {
            if (subjectBasicUiList[selectedSubjectIndex].TryToBuySubject())
            {
                //VibrationManager.Vibrate(VibrationManager.EVibrationIntensity.Medium);
                AudioManager.Instance.PlaySoundEffect("Buy");
                // Buy -> Use
                cardAmountText.transform.parent.gameObject.SetActive(false);
                purchaseText.gameObject.SetActive(true);
                purchaseText.text = "USE";
            }
            else
            {
                //VibrationManager.Vibrate(VibrationManager.EVibrationIntensity.Light);
                AudioManager.Instance.PlaySoundEffect("No");
                buyClickable.transform.DOShakePosition(shakeButtonDuration, shakeButtonStrength);
            }
        }
        else if(skinData == 1)
        {
            AudioManager.Instance.PlaySoundEffect("SelectSkin");
            // Use -> Used
            cardAmountText.transform.parent.gameObject.SetActive(false);
            purchaseText.gameObject.SetActive(true);
            purchaseText.text = "USED";

            currentUsedSkinIndex = PlayerPrefs.GetInt(SELECTED_SUBJECT, 0);
            
            PlayerPrefs.SetInt(subjectBasicUiList[currentUsedSkinIndex].SUBJECT_KEY_PROP, 1);

            currentUsedSkinIndex = selectedSubjectIndex;
            
            PlayerPrefs.SetInt(subjectBasicUiList[currentUsedSkinIndex].SUBJECT_KEY_PROP, 2);
            
            PlayerPrefs.SetInt(SELECTED_SUBJECT, currentUsedSkinIndex);
        }
        else if (skinData == 2)
        {
            //VibrationManager.Vibrate(VibrationManager.EVibrationIntensity.Light);
            AudioManager.Instance.PlaySoundEffect("No");
            buyClickable.transform.DOShakePosition(shakeButtonDuration, shakeButtonStrength);
        }
        
    }
    
}
