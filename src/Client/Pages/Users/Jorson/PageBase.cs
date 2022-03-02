using System;
using Client.Config;

namespace Client.Pages.Users.Jorson
{
    public abstract class PageBase
    {
        #region Public

        #region Member Methods
        public virtual void Initialize()
        {
            SetAppState();
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected virtual void SetAppState()
        {
            AppState.FaviconUri = "favicons/jorson/favicon.ico";
            AppState.IsSideNavHidden = true;
        }
        #endregion

        #endregion
    }
}