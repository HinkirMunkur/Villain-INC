using Munkur;
using UnityEngine;

public class FlagBasic : MonoBehaviour
{
    private bool oneTime = true;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (oneTime)
            {
                oneTime = false;
                
                col.transform.GetComponent<SubjectBasic>().SubjectStateMachineController.DoTransition(ESubjectState.IDLE);
                
                TransitionManager.Instance.EndSceneTransition(
                    LevelController.Instance.GetSceneNameWithIndex(LevelController.Instance.GetCurrentLevelIndex()));
            }
        }
    }
}
