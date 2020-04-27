using System;
using UnityEngine;

namespace RichUnity.State
{
    public abstract class State<TState> : MonoBehaviour where TState : State<TState>
    {
        public StateContext<TState> Context;
        
        public bool Is<T>() where T : TState
        {
            return GetType() == typeof(T);
        }

        public bool Is(Type type)
        {
            return GetType() == type;
        }
        
        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
        }
        
        public abstract void OnEnter(TState prevState, object parameter);

        public abstract void OnExit(TState nextState, object parameter);
    }
}
