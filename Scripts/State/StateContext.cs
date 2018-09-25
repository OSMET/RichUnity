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
	
		public virtual void SetState<T>(object parameter = null) where T : TState
		{
			var newState = States.Find(state => state.Is<T>());
			var oldState = CurrentState;
			CurrentState.OnExit(newState);
			CurrentState = newState;
			CurrentState.OnEnter(oldState, parameter);
		}
	}
}
