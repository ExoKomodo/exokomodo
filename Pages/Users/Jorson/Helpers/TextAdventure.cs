using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExoKomodo.Pages.Users.Jorson.Models;

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
        }
        #endregion

        #region Members
        public TextAdventureState CurrentState => _stateMachine.CurrentState;
        public TextAdventureInventory Inventory { get; private set; }
        public bool IsInitialized { get; private set; }
        public IList<TextAdventureState> States { get; private set; }
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

            IsInitialized = true;
            return IsInitialized;
        }

        public bool MoveTo(TextAdventureState state)
        {
            if (
                States?.FirstOrDefault(x => x?.Id == state?.Id) == null
                || (
                    state.RequiredItem != null && _inventory.HasItem(state.RequiredItem)
                )
            )
            {
                return false;
            }

            return _stateMachine.MoveTo(state);
        }

        public bool MoveTo(string stateId)
        {
            var state = States?.FirstOrDefault(state => state.Id == stateId);
            if (state == null)
            {
                return false;
            }

            return MoveTo(state);
        }

        public bool Update(int choice)
        {
            if (CurrentState == null)
            {
                return false;
            }
            if (choice < 0 || choice >= CurrentState.Options.Count)
            {
                return false;
            }
            return MoveTo(CurrentState.Options[choice]);
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