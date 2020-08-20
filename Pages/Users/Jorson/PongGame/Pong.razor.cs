using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.PongGame
{
    internal class PongBase : PageBase {}

    public partial class Pong : IDisposable
    {
        #region Public

        #region Constructors
        public Pong()
        {
            _base = new PongBase();
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
                _application = new PongApp(_jsRuntime, "pong-container");
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