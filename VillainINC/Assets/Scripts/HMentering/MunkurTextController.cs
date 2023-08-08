using UnityEngine;
using DG.Tweening;

public class MunkurTextController : MonoBehaviour
{
    [SerializeField] private Vector3 lastScalePos;
    [SerializeField] private float scaleDuration;

    public void ScaleText()
    {
        transform.DOScale(lastScalePos, scaleDuration);
    }
}
