using System.Collections.Generic;
using Munkur;
using UnityEngine;

public class StoreGameSceneButtonActivity : GameSceneButtonActivity
{
    [SerializeField] private List<GameObject> _disableGOlist;
    [SerializeField] private int storeFirstLevelIndex;
    
    protected override void Clicked()
    {
        foreach (var disableGO in _disableGOlist)
        {
            disableGO.SetActive(false);
        }
        
        CameraaManager.Instance.SetCamera(ECameraSystem.MainMenuCameraSystem, EMainMenuCameraType.MainMenuZoomIn);
        
        //LevelController.Instance.LoadLevelWithIndex(storeFirstLevelIndex);
    }
}
