using Munkur;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Clickable boxClickable;

    [SerializeField] private Animator maskAnimator;
    
    [SerializeField] private Transform blackBG;
    [SerializeField] private Transform mask;

    [SerializeField] private Vector3 lastScale = Vector3.one;
    [SerializeField] private float scaleDuration;

    private void Start()
    {
        boxClickable.gameObject.SetActive(false);
    }

    public void TriggerText()
    {
        DialogueTrigger.Instance.TriggerDialogue();
    }

    public void StopGameAndClickTrap()
    {
        boxClickable.gameObject.SetActive(true);
        boxClickable.OnClicked += TutorialFinish;

        maskAnimator.enabled = true;
        
        Time.timeScale = 0;
        blackBG.gameObject.SetActive(true);
        mask.gameObject.SetActive(true);
    }

    private void TutorialFinish()
    {
        maskAnimator.enabled = false;
        Time.timeScale = 1;

        blackBG.gameObject.SetActive(false);
        mask.gameObject.SetActive(false);
        boxClickable.OnClicked -= TutorialFinish;
    }
}
