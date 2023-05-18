using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressedSwitchTriggerHandler : MonoBehaviour
{
    [SerializeField] private SwitchBasic switchBasic;
    private bool pressedOnce = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") || col.CompareTag("Ground") || pressedOnce)
        {
            return;
        }

        pressedOnce = true;
        switchBasic.AutomaticSystem.RunSystem();
        switchBasic.SwitchAnimator.Play("SwitchPressed");
    }
}
