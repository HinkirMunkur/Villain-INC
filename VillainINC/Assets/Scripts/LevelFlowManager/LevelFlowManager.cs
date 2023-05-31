using UnityEngine;
using System;
using Munkur;

public class LevelFlowManager : Singletonn<LevelFlowManager>
{
    [SerializeField] private Executer executer;
    [SerializeField] private Transform priorityHolder;

    public Action OnStartGame;

    private void Start()
    {
        TransitionManager.Instance.StartSceneTransition();
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public void ExecuteSuccessPriorities()
    {
        executer.Execute(priorityHolder, (result) =>
        {
            if (result)
            {
                LevelController.Instance.SetCurrentSavedLevelIndex(LevelController.Instance.GetCurrentLevelIndex()+1);
                TransitionManager.Instance.EndSceneTransition(LevelController.Instance
                    .GetSceneNameWithIndex(LevelController.Instance.GetCurrentSavedLevelIndex()));
            }
        });
    }
    
}
