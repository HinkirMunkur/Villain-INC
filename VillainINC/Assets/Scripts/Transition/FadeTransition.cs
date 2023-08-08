using UnityEngine;
using DG.Tweening;

public class FadeTransition : Transition
{
    [SerializeField] private Color alphaZeroColor;
    [SerializeField] private Color alphaMaxColor;

    public override void ExecuteCustomStartTransition(float duration)
    {
        blackBackground.enabled = true;
        blackBackground.color = alphaMaxColor;
        blackBackground.DOColor(alphaZeroColor, duration);
    }

    public override void ExecuteCustomEndTransition(float duration)
    {
        blackBackground.enabled = true;
        blackBackground.color = alphaZeroColor;
        blackBackground.DOColor(alphaMaxColor, duration);
    }
}
