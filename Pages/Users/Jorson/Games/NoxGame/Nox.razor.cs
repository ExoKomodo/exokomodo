using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Helpers.P5;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.NoxGame
{
    internal class NoxBase : PageBase {}

    public partial class Nox : IDisposable
    {
        #region Public

        #region Constructors
        public Nox()
        {
            _base = new NoxBase();
            _base.Initialize();
        }
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _base.Dispose();
            _application.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override async Task OnInitializedAsync()
        {
            AppState.IsSideNavHidden = true;

            _adventure = await TextAdventure.LoadFromJsonAsync(_http, "data/jorson/games/nox/adventure.json");
            _adventure.Initialize();

            _application = new NoxApp(_jsRuntime, "nox-container", _adventure);
            _application.Start();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private TextAdventure _adventure { get; set; }
        private P5App _application { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private HttpClient _http { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}