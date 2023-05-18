using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBasic : MonoBehaviour
{
    [SerializeField] private AutomaticSystem automaticSystem;
    public AutomaticSystem AutomaticSystem => automaticSystem;
    
    [SerializeField] private Animator switchAnimator;
    public Animator SwitchAnimator => switchAnimator;

}
