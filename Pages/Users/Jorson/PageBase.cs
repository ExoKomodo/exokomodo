using System;
using ExoKomodo.Config;

namespace ExoKomodo.Pages.Users.Jorson
{
    public abstract class PageBase : IDisposable
    {
        #region Publie

        #region Member Methods
        public abstract void Dispose();

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