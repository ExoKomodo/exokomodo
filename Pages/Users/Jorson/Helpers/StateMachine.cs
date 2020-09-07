using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class StateMachine<T, TId>
        where T : State<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public StateMachine(TId defaultStateId)
            : this(new Dictionary<TId, T>()) {}

        public StateMachine(TId defaultStateId, IEnumerable<T> states)
        {
            _states = new Dictionary<TId, T>();

            foreach (var state in states)
            {
                if (state?.Info is null)
                {
                    throw new Exception("A State or State Info was null when creating StateMachine");
                }
                _states[state.Info.Id] = state;
            }
            DefaultStateId = defaultStateId;
        }

        public StateMachine(IDictionary<TId, T> states)
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
                    value?.Info is not null
                    && !_states.ContainsKey(value.Info.Id)
                )
                {
                    return;
                }
                _currentState = value;
            }
        }

        public readonly TId DefaultStateId;
        #endregion

        #region Member Methods
        public bool AddNextState(T state, StateInfo<TId> nextStateInfo)
        {
            if (_states.TryGetValue(nextStateInfo.Id, out T nextState))
            {
                return AddNextState(state, nextState);
            }
            return false;
        }
        public bool AddNextState(T state, T nextState)
        {
            if (state?.Info is null || nextState?.Info is null)
            {
                return false;
            }
            if (state.NextStates is null)
            {
                state.NextStates = new List<TId>();
            }
            state.NextStates.Add(nextState.Info.Id);
            _states[nextState.Info.Id] = nextState;
            return true;
        }
        
        public bool AddState(T state)
        {
            if (state?.Info is null)
            {
                return false;
            }
            _states[state.Info.Id] = state;
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

        public bool MoveTo(StateInfo<TId> info)
        {
            if (!_states.ContainsKey(info.Id))
            {
                return false;
            }
            return MoveTo(_states[info.Id]);
        }

        public void Reset()
        {
            CurrentState = _states[DefaultStateId];
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private T _currentState { get; set; }
        private IDictionary<TId, T> _states { get; set; }
        #endregion

        #region Member Methods
        private T TryMoveTo(T state)
        {
            if (
                state?.Info is null
                || CurrentState.NextStates is null
            )
            {
                return null;
            }
            
            var nextStateId = CurrentState.NextStates.FirstOrDefault(
                x => x.Equals(state.Info.Id)
            );
            if (
                nextStateId is null
                || !_states.TryGetValue(
                    nextStateId,
                    out T nextState
                )
            )
            {
                return null;
            }
            
            return nextState;
        }
        #endregion

        #endregion
    }
}