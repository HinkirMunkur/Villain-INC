using UnityEngine;

public class PressurePlateBasic : MonoBehaviour
{
    [SerializeField] private AutomaticSystem automaticSystem;
    public AutomaticSystem AutomaticSystem => automaticSystem;
    
    [SerializeField] private Animator plateAnimator;
    public Animator PlateAnimator => plateAnimator;
}
