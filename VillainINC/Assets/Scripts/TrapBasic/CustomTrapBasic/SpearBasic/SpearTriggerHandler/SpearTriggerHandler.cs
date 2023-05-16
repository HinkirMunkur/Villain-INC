using UnityEngine;

public class SpearTriggerHandler : MonoBehaviour
{
    [SerializeField] private SpearBasic spearBasic;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Wall"))
        {
            spearBasic.DisableSpearSlayCollider();
            spearBasic.StopAllCoroutines();
        }
    }
}
