using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Helpers.P5;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.Nox
{
    internal class NoxBase : PageBase {}

    public partial class Index : IDisposable
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new NoxBase();
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                _base.Initialize();
            }
        }

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

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
            {
                return;
            }
            _base.Dispose();
            _application.Dispose();
        }
        #endregion
    }
}