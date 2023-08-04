using UnityEngine;

public class TrapDoorBasic : AutomaticSystem
{
    [SerializeField] private Animator trapDoorAnimator;
    [SerializeField] private BoxCollider2D trapDoorCollider;

    public override void RunSystem()
    {
        trapDoorCollider.enabled = false;
        trapDoorAnimator.Play("Do");
    }
}
