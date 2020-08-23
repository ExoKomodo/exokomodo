using System.Collections.Generic;
using System.Linq;
using ExoKomodo.Pages.Users.Jorson.Models;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class StateMachine
    {
        #region Public

        #region Constructors
        public StateMachine()
        {
            _states = new Dictionary<string, State>();
        }

        public StateMachine(IDictionary<string, State> states)
        {
            _states = states;
        }
        #endregion

        #region Members
        public State CurrentState
        {
            get => _currentState;
            private set
            {
                // Only move to states that exist in the state machine
                if (
                    _states == null || (
                        value?.Id != null
                        && !_states.ContainsKey(value.Id)
                    )
                )
                {
                    return;
                }
                _currentState = value;
            }
        }
        #endregion

        #region Member Methods
        public bool AddNextState(State state, string nextStateId)
        {
            if (state?.Id == null || nextStateId == null || _states == null)
            {
                return false;
            }

            if (_states.TryGetValue(nextStateId, out State nextState))
            {
                return AddNextState(state, nextState);
            }
            return false;
        }
        public bool AddNextState(State state, State nextState)
        {
            if (state?.Id == null || nextState?.Id == null || _states == null)
            {
                return false;
            }

            if (state.NextStates == null)
            {
                state.NextStates = new List<string>();
            }
            state.NextStates.Add(nextState.Id);
            _states[nextState.Id] = nextState;
            return true;
        }
        
        public bool AddState(State state)
        {
            if (_states == null)
            {
                return false;
            }
            _states[state.Id] = state;
            return true;
        }

        public bool MoveTo(State state)
        {
            if (state?.Id == null || _states == null)
            {
                return false;
            }
            // If the current state is null, any state is valid.
            if (CurrentState == null)
            {
                CurrentState = state;
                return true;
            }

            var nextState = TryMoveTo(state);
            if (nextState == null)
            {
                return false;
            }
            return true;
        }

        public bool MoveTo(string id)
        {
            if (id == null || _states == null)
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
        private State _currentState { get; set; }
        private IDictionary<string, State> _states { get; set; }
        #endregion

        #region Member Methods
        private State TryMoveTo(State state)
        {
            if (state?.Id == null)
            {
                return null;
            }
            
            var nextStateId = CurrentState.NextStates?.FirstOrDefault(
                x => x != null && x == state.Id
            );
            if (!_states.TryGetValue(nextStateId, out State nextState))
            {
                return null;
            }
            
            return nextState;
        }
        #endregion

        #endregion
    }
}