using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedDoor : AutomaticSystem
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private BoxCollider2D doorCollider;
    public override void RunSystem()
    {
        doorAnimator.Play("DoorOpening");
        doorCollider.enabled = false;
    }
    public override void ExitSystem()
    {
        this.PlayAndCheckAnimationFinish(doorAnimator, "DoorClosing", () => doorCollider.enabled = true);
    }
}
