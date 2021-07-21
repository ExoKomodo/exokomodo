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

            _games = new List<string>
            {
                // "Corporation Tycoon",
                // "Kaiju",
                // "Nox",
                // "Pong",
            };
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
        #endregion

        #endregion

        #region Private

        #region Members
        private IList<string> _games { get; set; }
        private bool _isDisposed { get; set; }
        private PageBase _base { get; set; }
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
        }
        #endregion
    }
}