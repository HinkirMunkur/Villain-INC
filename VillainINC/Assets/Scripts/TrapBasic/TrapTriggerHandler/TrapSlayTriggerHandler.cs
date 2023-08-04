using UnityEngine;

public class TrapSlayTriggerHandler : MonoBehaviour
{
    [SerializeField] private TrapBasic trapBasic;
    [SerializeField] private string colliderTagName;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(colliderTagName))
        {
            if (trapBasic is ISlayer)
            {
                ((ISlayer)trapBasic).Slay(col.GetComponentInParent<SubjectBasic>());
            }
        }
    }
}
