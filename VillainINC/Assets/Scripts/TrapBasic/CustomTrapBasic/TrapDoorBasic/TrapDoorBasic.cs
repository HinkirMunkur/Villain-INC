using UnityEngine;

public class TrapDoorBasic : ClickableTrapBasic
{
    [SerializeField] private Animator trapDoorAnimator;
    [SerializeField] private BoxCollider2D trapDoorCollider;
    
    public override void TrapClicked()
    {
        trapDoorCollider.enabled = false;
        trapDoorAnimator.Play("Do");
    }
}
