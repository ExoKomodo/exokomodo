using Microsoft.JSInterop;
using ExoKomodo.Config;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson
{
    internal class IndexBase : PageBase {}

    public partial class Index : IDisposable
    {
        #region Public

        #region Constructors
        public Index()
        {
            _base = new IndexBase();
            _base.Initialize();
        }
        #endregion

        #region Constants
        public const string UserId = "jorson";
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _base.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnInitialized()
        {
            AppState.IsSideNavHidden = true;
        }

        protected override async Task OnInitializedAsync()
        {
            _self = (await _http.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self == null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        private PageBase _base { get; set; }
        private User _self;
        #endregion

        #endregion
    }
}