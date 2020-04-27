using System;
using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.State
{
	public class StateContext<TState> : MonoBehaviour where TState : State<TState>
	{
		public List<TState> States;
		public int BeginStateIndex;
		public bool EnterBeginStateOnStart = true;
		
		public TState CurrentState { get; protected set; }

		protected virtual void Awake()
		{
			for (int index = 0; index < States.Count; index++)
			{
				States[index].Context = this;
			}

			if (States.Count > 0)
			{
				CurrentState = States[BeginStateIndex]; //begin state
			}
		}

		protected virtual void Start()
		{
			if (EnterBeginStateOnStart && CurrentState)
			{
				CurrentState.OnEnter(null, null);
			}
		}

		public virtual TState GetState(Type type)
		{
			for (int index = 0; index < States.Count; index++)
			{
				var state = States[index];
				if (state.Is(type))
				{
					return state;
				}
			}
			return null;
		}
		
		public virtual T GetState<T>() where T : TState
		{
			return (T) GetState(typeof(T));
		}

		public virtual TState GetStateByObjectName(string objectName)
		{
			for (int index = 0; index < States.Count; index++)
			{
				var state = States[index];
				if (state.gameObject.name.Equals(objectName))
				{
					return state;
				}
			}
			return null;
		}
		
		public virtual T GetStateByObjectName<T>(string objectName) where T : TState
		{
			return (T) GetStateByObjectName(objectName);
		}

		public virtual void SetState(TState state, object enterParameter = null, object exitParameter = null)
		{
			var oldState = CurrentState;
			if (CurrentState != null)
			{
				CurrentState.OnExit(state, exitParameter);
			}
			CurrentState = state;
			CurrentState.OnEnter(oldState, enterParameter);
		}
	
		public virtual T SetState<T>(object enterParameter = null, object exitParameter = null) where T : TState
		{
			var newState = GetState<T>();
			SetState(newState, enterParameter, exitParameter);
			return newState;
		}

		public virtual TState SetState(Type type, object enterParameter = null, object exitParameter = null)
		{
			var newState = GetState(type);
			SetState(newState, enterParameter, exitParameter);
			return newState;
		}
		
		public virtual TState SetStateByObjectName(string objectName, object enterParameter = null, object exitParameter = null)
		{
			var newState = GetStateByObjectName(objectName);
			SetState(newState, enterParameter, exitParameter);
			return newState;
		}
		
		public virtual T SetStateByObjectName<T>(string objectName, object enterParameter = null, object exitParameter = null) where T : TState
		{
			return (T) SetStateByObjectName(objectName, enterParameter, exitParameter);
		}
	}
}
