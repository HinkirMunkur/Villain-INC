using UnityEngine;
using Munkur;

public class CraneBasic : ClickableTrapBasic
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxBasic boxBasic;

    private void Awake()
    {
        boxBasic.SetBoxStatic();
    }

    public override void TrapClicked()
    {
        AudioManager.Instance.PlaySoundEffect("BoxDrop");
        this.PlayAndCheckAnimationFinish(animator, "Do", () =>
        {
            boxBasic.SetBoxDynamic();
        });
    }
}
