using UnityEngine;

namespace RichUnity.State
{
    public abstract class State<TState> : MonoBehaviour where TState : State<TState>
    {
        public StateContext<TState> Context { get; set; }
        
        public bool Is<T>() where T : TState
        {
            return GetType() == typeof(T);
        }
        
        public abstract void OnEnter(TState prevState, object parameter);

        public abstract void OnExit(TState nextState);
    }
}
