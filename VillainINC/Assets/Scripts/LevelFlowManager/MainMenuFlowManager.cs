using UnityEngine;

public class MainMenuFlowManager : Singletonn<MainMenuFlowManager>
{
    [SerializeField] private SubjectBasicUI subjectBasicUI;
    private void Start()
    {
        if (PlayerPrefs.GetInt("SELECTED_SUBJECT", 0) == 0)
        {
            PlayerPrefs.SetInt(subjectBasicUI.SUBJECT_KEY_PROP, 2);
        }
        else
        {
            PlayerPrefs.SetInt(subjectBasicUI.SUBJECT_KEY_PROP, 1);
        }
    }
}
