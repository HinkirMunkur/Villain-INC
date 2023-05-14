using System.Collections;
using UnityEngine;
using DG.Tweening;
using Munkur;

public class HinkirTextController : MonoBehaviour
{
    [SerializeField] private Transform lastTransform;
    [SerializeField] private float moveDuration;
    
    [SerializeField] private float shakeDuration;
    [SerializeField] private float strength;
    [SerializeField] private int vibrato;

    [SerializeField] private Vector3 lastScalePos;
    [SerializeField] private float scaleDuration;

    [SerializeField] private float waitDurationBeforeScale;

    [SerializeField] private MunkurTextController munkurTextController;
    private void Start()
    {
        transform.DOMove(lastTransform.position, moveDuration).SetEase(Ease.InExpo);
        transform.DOShakeRotation(shakeDuration, strength, vibrato).OnComplete(() =>
        {
            StartCoroutine(WaitAndScale());
        });
    }

    private IEnumerator WaitAndScale()
    {
        yield return new WaitForSeconds(waitDurationBeforeScale);
        ScaleText();
        munkurTextController.ScaleText();
    }

    public void ScaleText()
    {
        transform.DOScale(lastScalePos, scaleDuration);
        StartCoroutine(WaitAndTranslateLevel());
    }
    
    private IEnumerator WaitAndTranslateLevel()
    {
        yield return new WaitForSeconds(scaleDuration-3);
        TransitionManager.Instance.EndSceneTransition(LevelController.Instance
            .GetSceneNameWithIndex(LevelController.Instance.GetCurrentLevelIndex()+1));
    }
}
