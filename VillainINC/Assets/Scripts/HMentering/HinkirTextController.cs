using System.Collections;
using Munkur;
using UnityEngine;

public class HinkirTextController : MonoBehaviour
{
    [SerializeField] private Transform lastPos;
    [SerializeField] private SubjectBasic subjectBasic;

    private bool oneTime = false;

    private void Update()
    {
        if (!oneTime && (transform.position.x > lastPos.transform.position.x))
        {
            oneTime = true;
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.IDLE);
            subjectBasic.SubjectStateMachineController.DoTransition(ESubjectState.NONE);
            StartCoroutine(EndLevelRoutine());
        }
    }

    private IEnumerator EndLevelRoutine()
    {
        yield return new WaitForSeconds(1f);
        TransitionManager.Instance.EndSceneTransition(LevelController.Instance.GetSceneNameWithIndex
            (LevelController.Instance.GetCurrentLevelIndex()+1));
    }
}
