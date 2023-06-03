using UnityEngine;

public class TutorialFallCollider : MonoBehaviour
{
    [SerializeField] private TutorialController tutorialController;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tutorialController.TriggerText();
        }
    }
}
