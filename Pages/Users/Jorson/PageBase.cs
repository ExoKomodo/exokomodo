using System;
using ExoKomodo.Config;

namespace ExoKomodo.Pages.Users.Jorson
{
    public abstract class PageBase : IDisposable
    {
        #region Publie

        #region Member Methods
        public virtual void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }

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
        protected virtual void SetAppState() {}
        #endregion

        #endregion
    }
}