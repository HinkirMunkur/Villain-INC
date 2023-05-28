using Munkur;
using UnityEngine;

public class FlagBasic : MonoBehaviour
{
    [SerializeField] private Transform circleTarget;
    private bool oneTime = true;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (oneTime)
            {
                oneTime = false;

                SubjectBasic subjectBasic = col.GetComponent<SubjectBasic>();
                
                subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
                subjectBasic.SubjectAnimationController.PlayAnimation(ESubjectAnimation.IDLE);

                circleTarget.position = col.transform.position;
                
                TransitionManager.Instance.EndSceneTransition(
                    LevelController.Instance.GetSceneNameWithIndex(LevelController.Instance.GetCurrentLevelIndex()));
            }
        }
    }
}
