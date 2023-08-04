using System.Collections.Generic;
using UnityEngine;
using System;

public interface IContext<EState>
{
    void SetState(EState newEStates);
    void DoStateTransition(EState newEStates);
}

namespace Munkur
{
    public abstract class StateMachine<EState> : MonoBehaviour, IContext<EState>
    {
        [SerializeField] private List<StateToClassDictionary> mockStateDictionary;
        [SerializeField] private bool isDebugEnabled;
    
        protected Dictionary<EState, State> statesDictionary;

        protected Dictionary<EState, Action> stateTransitionDictionary;

        protected State currState;

        protected EState eCurrState;

        public EState ECurrState => eCurrState;

        [Serializable]
        public class StateToClassDictionary
        {
            public EState eStates;
            public State stateClass;
        }
    
        protected virtual void Awake()
        {
            statesDictionary = new Dictionary<EState, State>();
        
            foreach (StateToClassDictionary item in mockStateDictionary)
            {
                statesDictionary.Add(item.eStates, item.stateClass);
            }
        }

        private void Do() => currState.Do();
        private void Done() => currState.Done();

        public void DoStateTransition(EState newEStates)
        {
            if (currState.Equals(newEStates))
            {
                return;
            }
            Done();
            stateTransitionDictionary[newEStates]?.Invoke();
        }
    
        public void SetState(EState newEStates)
        {
            eCurrState = newEStates;
            currState = statesDictionary[newEStates];
            Do();
        
            if (isDebugEnabled) { Debug.Log(currState); }
        }
    }
}