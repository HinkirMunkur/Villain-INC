using UnityEngine;

public class SpearTriggerHandler : MonoBehaviour
{
    [SerializeField] private SpearBasic spearBasic;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") || col.CompareTag("Wall") || col.CompareTag("PushBox"))
        {
            spearBasic.DisableSpearSlayCollider();
            spearBasic.StopAllCoroutines();
        }
    }
}
