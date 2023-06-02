using System.Collections;
using Munkur;
using UnityEngine;

public class FanAffectAreaTriggerHandler : MonoBehaviour
{
    [SerializeField] private FanBasic fanBasic;

    private bool isObjectInFanArea = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("PushBox") || col.CompareTag("Wall")) 
        {
            isObjectInFanArea = true;
            StartCoroutine(AddForceCont(col.attachedRigidbody));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("PushBox") || col.CompareTag("Wall")) 
        {
            isObjectInFanArea = false;
        }
    }

    private IEnumerator AddForceCont(Rigidbody2D objectRigidbody)
    {
        AudioManager.Instance.PlaySoundEffect("Fan");

        while (isObjectInFanArea)
        {
            objectRigidbody.AddForce(fanBasic.FanForceVector * Time.deltaTime);
            yield return null;
        }
    }
}
