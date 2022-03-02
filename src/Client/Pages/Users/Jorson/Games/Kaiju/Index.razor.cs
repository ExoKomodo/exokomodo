using Microsoft.JSInterop;
using Client.Config;
using Client.Helpers.P5;
using Microsoft.AspNetCore.Components;
using System;

namespace Client.Pages.Users.Jorson.Games.Kaiju
{
    internal class KaijuBase : PageBase {}

    public partial class Index
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new KaijuBase();
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
                _application = new KaijuApp(_jsRuntime, "kaiju-container");
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
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}