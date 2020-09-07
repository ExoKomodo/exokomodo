using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventure<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public TextAdventure()
        {
            _inventory = new TextAdventureInventory();
            _stateMachine = new StateMachine<TextAdventureState<TId>, TId>(DefaultState);
            States = new List<TextAdventureState<TId>>();
        }
        #endregion

        #region Members
        [JsonIgnore]
        public bool BlockedTransition { get; private set; }
        
        [JsonIgnore]
        public TextAdventureState<TId> CurrentState => _stateMachine.CurrentState;
        

        [JsonIgnore]
        public bool IsInitialized { get; private set; }
        
        public TId DefaultState { get; set; }

        public IList<TextAdventureState<TId>> States { get; set; }
        #endregion

        #region Static Methods
        public static T LoadFromJson<T>(HttpClient http, string jsonUrl)
            where T : TextAdventure<TId>
            => LoadFromJsonAsync<T>(http, jsonUrl).Result;
        
        public static async Task<T> LoadFromJsonAsync<T>(HttpClient http, string jsonUrl)
            where T : TextAdventure<TId>
            => await http.GetFromJsonAsync<T>(jsonUrl);
        #endregion

        #region Member Methods
        public bool Initialize()
        {
            if (IsInitialized || States is null)
            {
                return IsInitialized;
            }
            _stateMachine = new StateMachine<TextAdventureState<TId>, TId>(DefaultState, States);
            _stateMachine.MoveTo(States.FirstOrDefault());

            IsInitialized = true;
            return IsInitialized;
        }

        public bool MoveTo(TextAdventureState<TId> nextState)
        {
            if (States?.FirstOrDefault(state => state?.Info == nextState?.Info) is null)
            {
                return false;
            }
            if (nextState?.RequiredItem is not null && !_inventory.Contains(nextState?.RequiredItem))
            {
                BlockedTransition = true;
                return false;
            }

            if (_stateMachine.MoveTo(nextState))
            {
                if (CurrentState.AcquiredItem is not null)
                {
                    _inventory.Add(CurrentState.AcquiredItem);
                }
                return true;
            }
            return false;
        }

        public bool MoveTo(StateInfo<TId> stateInfo) => stateInfo is null ? false : MoveTo(stateInfo.Id);

        public bool MoveTo(TId stateId)
        {
            if (States is null)
            {
                return false;
            }
            var state = States?.FirstOrDefault(
                state => state.Info.Id.Equals(stateId)
            );
            if (state is null)
            {
                return false;
            }

            return MoveTo(state);
        }

        public void Reset()
        {
            _inventory.Clear();
            _stateMachine.Reset();
        }

        public bool Update(int choice)
        {
            BlockedTransition = false;
            if (CurrentState is null)
            {
                return false;
            }
            if (
                choice < 0
                || choice >= CurrentState.Options.Count
                || choice >= CurrentState.NextStates.Count
            )
            {
                return false;
            }
            return MoveTo(CurrentState.NextStates[choice]);
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        protected TextAdventureInventory _inventory { get; set; }
        protected StateMachine<TextAdventureState<TId>, TId> _stateMachine { get; set; }
        #endregion

        #endregion
    }
}