using Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Client.Pages.Webring.Jorson;
using Client.Services;

namespace Client.Pages.Webring.Nbarlow.HowOldAmI
{
    internal class IndexBase : PageBase {}

    public partial class Index
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new IndexBase();   
        }
        #endregion

        #region Constants
        public const string UserId = "nbarlow";
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
            _self = await _webringService.GetByIdAsync(UserId);
            if (_self is null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        [Inject]
        private WebringService _webringService { get; set; }
        private PageBase _base { get; set; }
        private Page _self;
        #endregion

        #endregion
    }
}