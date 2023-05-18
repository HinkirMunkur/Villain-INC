using Munkur;
using UnityEngine;

public class FlagBasic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            TransitionManager.Instance.EndSceneTransition(
                LevelController.Instance.GetSceneNameWithIndex(LevelController.Instance.GetCurrentLevelIndex()));
        }
    }
}
