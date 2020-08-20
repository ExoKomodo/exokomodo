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
            AppState.OnIsSideNavHiddenChange -= StateHasChanged;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnInitialized()
        {
            AppState.OnIsSideNavHiddenChange += StateHasChanged;
        }
        #endregion

        #endregion
    }
}