using System.Collections;
using UnityEngine;

public class FanAffectAreaTriggerHandler : MonoBehaviour
{
    [SerializeField] private FanBasic fanBasic;

    private bool isPlayerInFanArea = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInFanArea = true;
            StartCoroutine(AddForceCont(col.GetComponent<SubjectBasic>()));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerInFanArea = false;
        }
    }

    private IEnumerator AddForceCont(SubjectBasic subjectBasic)
    {
        while (isPlayerInFanArea)
        {
            subjectBasic.MovementBehaviour.AddForceToPlayer(fanBasic.FanForceVector);
            yield return null;
        }
    }
}
