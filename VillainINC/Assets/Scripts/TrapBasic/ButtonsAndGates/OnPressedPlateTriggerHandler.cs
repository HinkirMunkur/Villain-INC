using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Munkur;

public class OnPressedPlateTriggerHandler : MonoBehaviour
{
    [SerializeField] private PressurePlateBasic pressurePlateBasic;
    private int itemsOnTop = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            return;
        }

        AudioManager.Instance.PlaySoundEffect("");
        itemsOnTop++;
        pressurePlateBasic.AutomaticSystem.RunSystem();
        pressurePlateBasic.PlateAnimator.Play("PressedPlate");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        itemsOnTop--;
        if (itemsOnTop == 0)
        {
            pressurePlateBasic.AutomaticSystem.ExitSystem();
            pressurePlateBasic.PlateAnimator.Play("ReleasedPlate");
        }
    }
}
