using System;

namespace Client.Config
{
    public static class AppState
    {
        #region Public

        #region Defaults
        public const string DEFAULT_FAVICON_URI = "favicons/favicon.ico";
        #endregion

        #region Fields
        public static string FaviconUri
        {
            get => _faviconUri;
            set
            {
                _faviconUri = value;
                OnFaviconUriChange?.Invoke();
                NotifyStateChanged();
            }
        }
        public static event Action OnFaviconUriChange;
        public static event Action OnChange;
        #endregion

        #region Methods
        public static void Reset()
        {
            FaviconUri = DEFAULT_FAVICON_URI;
        }
        #endregion

        #endregion

        #region Private

        #region Fields
        private static string _faviconUri { get; set; } = DEFAULT_FAVICON_URI;
        #endregion

        #region Methods
        private static void NotifyStateChanged() => OnChange?.Invoke();
        #endregion

        #endregion
    }
}