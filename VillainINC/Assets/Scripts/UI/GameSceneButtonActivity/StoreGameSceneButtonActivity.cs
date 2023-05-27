using System.Collections.Generic;
using DG.Tweening;
using Munkur;
using UnityEngine;

public class StoreGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private List<GameObject> _disableGOlist;
    [SerializeField] private int storeFirstLevelIndex;

    [SerializeField] private Material tvEffectMaterial;
    [SerializeField] private float screenEffectFadeDuration;
    [SerializeField] private float lastOpacityValue;
    
    protected override void Clicked()
    {
        foreach (var disableGO in _disableGOlist)
        {
            disableGO.SetActive(false);
        }

        SetTvEffectOpacity();
        
        CameraaManager.Instance.SetCamera(ECameraSystem.MainMenuCameraSystem, EMainMenuCameraType.MainMenuZoomIn);

        //LevelController.Instance.LoadLevelWithIndex(storeFirstLevelIndex);
    }

    private void SetTvEffectOpacity()
    {
        float initOpacityValue = tvEffectMaterial.GetFloat("_Opacity");

        DOTween.To(() => initOpacityValue, x => initOpacityValue = x, lastOpacityValue, screenEffectFadeDuration)
            .OnUpdate(() => {
                tvEffectMaterial.SetFloat("_Opacity", initOpacityValue);
            }).OnComplete(() =>
        {
            //ViewportHandler.Instance.SetCamera(CameraaManager.Instance.GetActiveVirtualCamera(ECameraSystem.MainMenuCameraSystem));
            //ViewportHandler.Instance.ComputeResolution();
        });
    }
}
