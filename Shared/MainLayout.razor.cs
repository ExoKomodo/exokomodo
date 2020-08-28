using System;
using ExoKomodo.Config;

namespace ExoKomodo.Shared
{
    public partial class MainLayout : IDisposable
    {
        #region Public

        #region Member Methods
        public void Dispose()
        {
            AppState.OnFaviconUriChange -= StateHasChanged;
            AppState.OnIsSideNavHiddenChange -= StateHasChanged;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnInitialized()
        {
            AppState.OnFaviconUriChange += StateHasChanged;
            AppState.OnIsSideNavHiddenChange += StateHasChanged;
        }
        #endregion

        #endregion
    }
}