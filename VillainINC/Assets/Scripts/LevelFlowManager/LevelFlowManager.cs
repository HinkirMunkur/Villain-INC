using UnityEngine;
using System;
using Munkur;

public class LevelFlowManager : Singletonn<LevelFlowManager>
{
    [SerializeField] private Executer executer;
    [SerializeField] private Transform priorityHolder;

    public Action OnStartGame;

    public bool IsLevelFinished { get; set; } = false;
    
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
        if (!FlagBasic.IsSubjectTouchFlag)
        {
            executer.Execute(priorityHolder, (result) =>
            {
                if (result)
                {
                    IsLevelFinished = true;
                    
                    LevelController.Instance.SetCurrentSavedLevelIndex(LevelController.Instance.GetCurrentLevelIndex()+1);
                    TransitionManager.Instance.EndSceneTransition(LevelController.Instance
                        .GetSceneNameWithIndex(LevelController.Instance.GetCurrentSavedLevelIndex()));
                }
            });   
        }
    }
}
