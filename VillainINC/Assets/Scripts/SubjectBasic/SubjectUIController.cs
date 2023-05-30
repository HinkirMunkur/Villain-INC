using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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

    private const string SELECTED_SUBJECT = "SELECTED_SUBJECT";

    private int selectedSubjectIndex = 0;
    
    public void InitSubjectUIController()
    {
        selectedSubjectIndex = PlayerPrefs.GetInt(SELECTED_SUBJECT, 0);

        if (selectedSubjectIndex == 0)
        {
            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex + 1].transform.position = rightTransform.position;
        }
        else if (selectedSubjectIndex == subjectBasicUiList.Count - 1)
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex - 1].transform.position = leftTransform.position;
        }
        else
        {
            subjectBasicUiList[selectedSubjectIndex-1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex - 1].transform.position = leftTransform.position;

            subjectBasicUiList[selectedSubjectIndex+1].gameObject.SetActive(true);
            subjectBasicUiList[selectedSubjectIndex + 1].transform.position = leftTransform.position;
        }
        
        subjectBasicUiList[selectedSubjectIndex].gameObject.SetActive(true);
        subjectBasicUiList[selectedSubjectIndex].transform.position = centerTransform.position;

        SubsClickable();
    }

    private void SubsClickable()
    {
        leftClickable.OnClicked += OnLeftButtonClicked;
        rightClickable.OnClicked += OnRightButtonClicked;
        buyClickable.OnClicked += OnBuyButtonClicked;
    }
    
    public void UnsubsClickable()
    {
        leftClickable.OnClicked -= OnLeftButtonClicked;
        rightClickable.OnClicked -= OnRightButtonClicked;
        buyClickable.OnClicked -= OnBuyButtonClicked;
    }

    private void OnLeftButtonClicked()
    {
        if (selectedSubjectIndex == 0)
        {
            return;
        }

        subjectBasicUiList[selectedSubjectIndex + 1].transform.DOScale(Vector3.zero, moveDuration).OnComplete(
            () => subjectBasicUiList[selectedSubjectIndex + 1].gameObject.SetActive(false));
        
        subjectBasicUiList[selectedSubjectIndex].transform.DOMove(rightTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex-1].transform.DOMove(centerTransform.position, moveDuration);
    }

    private void OnRightButtonClicked()
    {
        if (selectedSubjectIndex == subjectBasicUiList.Count - 1)
        {
            return;
        }

        subjectBasicUiList[selectedSubjectIndex + 1].transform.DOMove(centerTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex].transform.DOMove(leftTransform.position, moveDuration);
        subjectBasicUiList[selectedSubjectIndex-1].transform.DOScale(Vector3.zero, moveDuration);
    }

    private void OnBuyButtonClicked()
    {
        
    }
    
}
