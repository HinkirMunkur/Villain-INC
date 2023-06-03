using UnityEngine;

public class TutorialTrapCollider : MonoBehaviour
{
    [SerializeField] private TutorialController tutorialController;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tutorialController.StopGameAndClickTrap();
        }
    }
}
