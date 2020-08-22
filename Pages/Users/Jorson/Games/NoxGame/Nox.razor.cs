using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Helpers.P5;
using Microsoft.AspNetCore.Components;
using System;

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
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                _application = new NoxApp(_jsRuntime, "nox-container");
                _application.Start();
            }
        }

        protected override void OnInitialized()
        {
            AppState.IsSideNavHidden = true;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private P5App _application { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}