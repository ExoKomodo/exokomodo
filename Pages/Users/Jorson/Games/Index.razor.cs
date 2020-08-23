using ExoKomodo.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
                "Nox",
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
        private bool _isDisposed { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}