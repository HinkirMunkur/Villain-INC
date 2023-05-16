using UnityEngine;

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
        this.PlayAndCheckAnimationFinish(animator, "Do", () =>
        {
            boxBasic.SetBoxDynamic();
        });
    }
}
