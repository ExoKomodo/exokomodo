using System;

namespace ExoKomodo.Config
{
    public static class AppState
    {
        #region Public

        #region Members
        public static bool IsSidebarHidden
        {
            get => _isSidebarHidden;
            set
            {
                _isSidebarHidden = value;
                OnIsSideBarHiddenChange?.Invoke();
                NotifyStateChanged();
            }
        }
        public static event Action OnIsSideBarHiddenChange;
        public static event Action OnChange;
        #endregion

        #endregion

        #region Private

        #region Members
        private static bool _isSidebarHidden { get; set; }
        #endregion

        #region Member Methods
        private static void NotifyStateChanged() => OnChange?.Invoke();
        #endregion

        #endregion
    }
}