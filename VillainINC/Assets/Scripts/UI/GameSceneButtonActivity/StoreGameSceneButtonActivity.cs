using System.Collections.Generic;
using DG.Tweening;
using Munkur;
using UnityEngine;

public class StoreGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private List<GameObject> _disableGOlist;
    [SerializeField] private StoreUIController storeUIController;
    
    [SerializeField] private float screenEffectDuration;

    [SerializeField] private SpriteRenderer screenBG;
    [SerializeField] private Color lastbgColor;

    private Color initialScreenBGcolor;

    private void Start()
    {
        initialScreenBGcolor = screenBG.color;
    }

    protected override void Clicked()
    {
        OpenStoreUI();
    }

    public void OpenStoreUI()
    {
        foreach (var disableGO in _disableGOlist)
        {
            disableGO.SetActive(false);
        }
        
        storeUIController.gameObject.SetActive(true);
        storeUIController.InitStoreUI();
        
        screenBG.DOColor(lastbgColor, screenEffectDuration);
        CameraaManager.Instance.SetCamera(ECameraSystem.MainMenuCameraSystem, EMainMenuCameraType.MainMenuZoomIn);
    }
    
    public void CloseStoreUI()
    {
        foreach (var disableGO in _disableGOlist)
        {
            disableGO.SetActive(true);
        }
        
        storeUIController.gameObject.SetActive(false);
        screenBG.DOColor(initialScreenBGcolor, screenEffectDuration);
        CameraaManager.Instance.SetCamera(ECameraSystem.MainMenuCameraSystem, EMainMenuCameraType.MainMenuZoomOut);
    }

}
