using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class StateMachine<T> where T : State
    {
        #region Public

        #region Constructors
        public StateMachine() : this(new Dictionary<string, T>()) {}

        public StateMachine(IEnumerable<T> states)
        {
            _states = new Dictionary<string, T>();

            foreach (var state in states)
            {
                if (state?.Id is null)
                {
                    throw new Exception("A State or State Id was null when creating StateMachine");
                }
                _states[state.Id] = state;
            }
        }

        public StateMachine(IDictionary<string, T> states)
        {
            _states = states;
        }
        #endregion

        #region Members
        public T CurrentState
        {
            get => _currentState;
            private set
            {
                // Only move to states that exist in the state machine
                if (
                    value?.Id !is null
                    && !_states.ContainsKey(value.Id)
                )
                {
                    return;
                }
                _currentState = value;
            }
        }
        #endregion

        #region Member Methods
        public bool AddNextState(T state, string nextStateId)
        {
            if (state?.Id is null || nextStateId is null)
            {
                return false;
            }

            if (_states.TryGetValue(nextStateId, out T nextState))
            {
                return AddNextState(state, nextState);
            }
            return false;
        }
        public bool AddNextState(T state, T nextState)
        {
            if (state?.Id is null || nextState?.Id is null)
            {
                return false;
            }

            if (state.NextStates is null)
            {
                state.NextStates = new List<string>();
            }
            state.NextStates.Add(nextState.Id);
            _states[nextState.Id] = nextState;
            return true;
        }
        
        public bool AddState(T state)
        {
            _states[state.Id] = state;
            return true;
        }

        public bool MoveTo(T state)
        {
            // If the current state is null, any state is valid.
            if (CurrentState is null)
            {
                CurrentState = state;
                return true;
            }

            var nextState = TryMoveTo(state);
            if (nextState is null)
            {
                return false;
            }
            CurrentState = nextState;
            return true;
        }

        public bool MoveTo(string id)
        {
            if (id is null)
            {
                return false;
            }
            if (!_states.ContainsKey(id))
            {
                return false;
            }
            return MoveTo(_states[id]);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private T _currentState { get; set; }
        private IDictionary<string, T> _states { get; set; }
        #endregion

        #region Member Methods
        private T TryMoveTo(T state)
        {
            if (state?.Id is null)
            {
                return null;
            }
            if (state.Id == "default")
            {
                return state;
            }
            
            var nextStateId = CurrentState.NextStates?.FirstOrDefault(
                x => x !is null && x == state?.Id
            );
            if (!_states.TryGetValue(nextStateId, out T nextState))
            {
                return null;
            }
            
            return nextState;
        }
        #endregion

        #endregion
    }
}