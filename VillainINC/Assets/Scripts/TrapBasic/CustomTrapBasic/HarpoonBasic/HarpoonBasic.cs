using UnityEngine;

public class HarpoonBasic : ClickableTrapBasic
{
    [SerializeField] private SpearBasic spearBasic;
    [SerializeField] private Vector2 forceToSpear;

    private void Awake()
    {
        spearBasic.SetSpearStatic();
        spearBasic.DisableSpearSlayCollider();
    }

    public override void TrapClicked()
    {
        spearBasic.SetSpearDynamic();
        spearBasic.EnableSpearSlayCollider();
        StartCoroutine(spearBasic.AddForceUntilCrush(forceToSpear));
    }
}
