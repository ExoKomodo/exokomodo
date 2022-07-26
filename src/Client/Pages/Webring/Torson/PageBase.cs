using System;
using Client.Config;

namespace Client.Pages.Webring.Torson
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
            AppState.FaviconUri = "favicons/favicon.ico";
        }
        #endregion

        #endregion
    }
}