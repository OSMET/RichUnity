using System;
using System.Collections.Generic;
using RichUnity.StringUtils;
using TMPro;
using UnityEngine;

namespace RichUnity.State
{
	public class StateContext<TState> : MonoBehaviour where TState : State<TState>
	{
		public List<TState> States;
		public int BeginStateIndex;
		public bool EnterBeginStateOnStart = true;
		[SerializeField]
		private bool useDictionaryGetOptimization = true;
		
		public TState CurrentState { get; protected set; }
		
		public bool ShowDebugMessages;

		private Dictionary<Type, TState> statesDictionary;

		protected virtual void Awake()
		{
			if (useDictionaryGetOptimization)
			{
				statesDictionary = new Dictionary<Type, TState>(States.Count);
				for (int index = 0; index < States.Count; index++)
				{
					var state = States[index];
					
					state.Context = this;

					statesDictionary.Add(state.GetType(), state);
				}
			}
			else
			{
				for (int index = 0; index < States.Count; index++)
				{
					States[index].Context = this;
				}
			}
		}

		protected virtual void Start()
		{
			if (EnterBeginStateOnStart)
			{
				CurrentState = States[BeginStateIndex]; //begin state

				CurrentState.OnEnter(null, null);
			}
		}

		public virtual TState GetState(Type type)
		{
			if (useDictionaryGetOptimization)
			{
				if (statesDictionary.ContainsKey(type))
				{
					return statesDictionary[type];
				}
			}
			else
			{
				for (int index = 0; index < States.Count; index++)
				{
					var state = States[index];
					if (state.Is(type))
					{
						return state;
					}
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
				if (state.gameObject.name.OrdinalEquals(objectName))
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
#if UNITY_EDITOR
			if (ShowDebugMessages)
			{
				Debug.Log(CurrentState == null ? "No State" : CurrentState.GetType().ToString());
				Debug.Log(state.GetType().ToString());
			}
#endif
			
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
