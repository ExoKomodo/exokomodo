using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventure
    {
        #region Public

        #region Constructors
        public TextAdventure()
        {
            _inventory = new TextAdventureInventory();
            _stateMachine = new StateMachine<TextAdventureState>();
            States = new List<TextAdventureState>();
        }
        #endregion

        #region Members
        [JsonIgnore]
        public TextAdventureState CurrentState => _stateMachine.CurrentState;
        [JsonIgnore]
        public TextAdventureInventory Inventory { get; private set; }
        [JsonIgnore]
        public bool IsInitialized { get; private set; }
        public IList<TextAdventureState> States { get; set; }
        #endregion

        #region Static Methods
        public static TextAdventure LoadFromJson(HttpClient http, string jsonUrl) => LoadFromJsonAsync(http, jsonUrl).Result;
        
        public static async Task<TextAdventure> LoadFromJsonAsync(HttpClient http, string jsonUrl)
        {
            return await http.GetFromJsonAsync<TextAdventure>(jsonUrl);
        }
        #endregion

        #region Member Methods
        public bool Initialize()
        {
            if (IsInitialized || States == null)
            {
                return IsInitialized;
            }
            _stateMachine = new StateMachine<TextAdventureState>(States);
            _stateMachine.MoveTo(States.FirstOrDefault());

            IsInitialized = true;
            return IsInitialized;
        }

        public bool MoveTo(TextAdventureState nextState)
        {
            if (
                States?.FirstOrDefault(state => state?.Id == nextState?.Id) == null
                || (
                    nextState.RequiredItem != null && _inventory.HasItem(nextState.RequiredItem)
                )
            )
            {
                return false;
            }

            return _stateMachine.MoveTo(nextState);
        }

        public bool MoveTo(string stateId)
        {
            var state = States?.FirstOrDefault(state => state?.Id == stateId);
            if (state == null)
            {
                return false;
            }

            return MoveTo(state);
        }

        public void Reset()
        {
            _inventory.Reset();
            MoveTo(States?.FirstOrDefault());
        }

        public bool Update(int choice)
        {
            if (CurrentState == null)
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
        protected StateMachine<TextAdventureState> _stateMachine { get; set; }
        #endregion

        #endregion
    }
}