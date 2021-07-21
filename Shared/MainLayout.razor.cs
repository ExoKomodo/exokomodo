using System;
using ExoKomodo.Config;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ExoKomodo.Shared
{
    public partial class MainLayout : IDisposable
    {
        #region Public

        #region Member Methods
        public void Dispose()
        {
            AppState.OnFaviconUriChange -= UpdateFavicon;
            AppState.OnIsSideNavHiddenChange -= StateHasChanged;
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        [Inject]
        protected IJSRuntime _JS { get; set; }
        #endregion

        #region Member Methods
        protected override void OnInitialized()
        {
            AppState.OnFaviconUriChange += UpdateFavicon;
            AppState.OnIsSideNavHiddenChange += StateHasChanged;
        }

        protected void UpdateFavicon()
        {
            _JS.InvokeVoidAsync("updateFavicon", AppState.FaviconUri);
            StateHasChanged();
        }
        #endregion

        #endregion
    }
}