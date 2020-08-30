using System;
using ExoKomodo.Config;

namespace ExoKomodo.Pages.Users.Jorson
{
    public abstract class PageBase : IDisposable
    {
        #region Publie

        #region Member Methods
        public virtual void Initialize()
        {
            SetAppState();
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        protected bool _isDisposed { get; set; }
        #endregion

        #region Member Methods
        protected virtual void SetAppState()
        {
            AppState.FaviconUri = "favicons/jorson/favicon.ico";
            AppState.IsSideNavHidden = true;
        }
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
            _isDisposed = true;
        }
        #endregion
    }
}