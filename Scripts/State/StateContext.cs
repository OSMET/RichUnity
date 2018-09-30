using System;
using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.State
{
	public class StateContext<TState> : MonoBehaviour where TState : State<TState>
	{
		public List<TState> States;
		public int BeginStateIndex;
		public bool BeginStateApplyOnEnter = true;
		
		public TState CurrentState { get; private set; }

		protected virtual void Awake ()
		{
			foreach (var state in States)
			{
				state.Context = this;
			}
		
			CurrentState = States[BeginStateIndex]; //begin state

			if (BeginStateApplyOnEnter)
			{
				CurrentState.OnEnter(null, null);
			}
		}

		public virtual TState GetState(Type type)
		{
			return States.Find(state => state.Is(type));
		}
		
		public virtual T GetState<T>() where T : TState
		{
			return (T) GetState(typeof(T));
		}

		public virtual TState GetStateByObjectName(string objectName)
		{
			return States.Find(state => state.gameObject.name.Equals(objectName));
		}
		
		public virtual T GetStateByObjectName<T>(string objectName) where T : TState
		{
			return (T) GetStateByObjectName(objectName);
		}

		private void SetState(TState state, object parameter)
		{
			var oldState = CurrentState;
			CurrentState.OnExit(state);
			CurrentState = state;
			CurrentState.OnEnter(oldState, parameter);
		}
	
		public virtual T SetState<T>(object parameter = null) where T : TState
		{
			var newState = GetState<T>();
			SetState(newState, parameter);
			return newState;
		}

		public virtual TState SetState(Type type, object parameter = null)
		{
			var newState = GetState(type);
			SetState(newState, parameter);
			return newState;
		}
		
		public virtual TState SetStateByObjectName(string objectName, object parameter = null)
		{
			var newState = GetStateByObjectName(objectName);
			SetState(newState, parameter);
			return newState;
		}
		
		public virtual T SetStateByObjectName<T>(string objectName, object parameter = null) where T : TState
		{
			return (T) SetStateByObjectName(objectName, parameter);
		}
	}
}
