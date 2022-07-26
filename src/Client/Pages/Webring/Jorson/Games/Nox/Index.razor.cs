using Microsoft.JSInterop;
using Client.Config;
using Client.Helpers.P5;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using Client.Pages.Webring.Jorson.Helpers;
using System.Threading.Tasks;
using Client.Http;

namespace Client.Pages.Webring.Jorson.Games.Nox
{
    internal class NoxBase : PageBase {}

    public partial class Index
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
            _adventure = await TextAdventure<string>.LoadFromJsonAsync<TextAdventure<string>>(
                _httpLocal.Client,
                "data/jorson/games/nox/adventure.json"
            );
            _adventure.Initialize();

            _application = new NoxApp(_jsRuntime, "nox-container", _adventure);
            _application.Start();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private TextAdventure<string> _adventure { get; set; }
        private P5App _application { get; set; }
        [Inject]
        private LocalClient _httpLocal { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}