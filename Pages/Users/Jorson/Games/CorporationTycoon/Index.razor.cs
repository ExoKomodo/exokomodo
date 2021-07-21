using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Helpers.P5;
using System.Threading.Tasks;
using System;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    internal class CorporationTycoonBase : PageBase {}

    public partial class Index : IDisposable
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new CorporationTycoonBase();
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _base.Initialize();
                _application = new CorporationTycoonApp(JS, "corporation-tycoon-container");
                await _application.StartAsync();
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
        private PageBase _base { get; set; }
        private bool _isDisposed { get; set; }
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