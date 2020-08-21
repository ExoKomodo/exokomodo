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
using ExoKomodo.Models.Jorson;

namespace ExoKomodo.Pages.Users.Jorson.Games
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

            _games = new List<string>
            {
                "Pong",
            };
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
        #endregion

        #endregion

        #region Private

        #region Members
        private IList<string> _games { get; set; }
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}