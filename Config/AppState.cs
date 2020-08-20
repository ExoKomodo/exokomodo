using System;

namespace ExoKomodo.Config
{
    public static class AppState
    {
        #region Public

        #region Members
        public static bool IsSideNavHidden
        {
            get => _isSideNavHidden;
            set
            {
                _isSideNavHidden = value;
                OnIsSideNavHiddenChange?.Invoke();
                NotifyStateChanged();
            }
        }
        public static event Action OnIsSideNavHiddenChange;
        public static event Action OnChange;
        #endregion

        #endregion

        #region Private

        #region Members
        private static bool _isSideNavHidden { get; set; }
        #endregion

        #region Member Methods
        private static void NotifyStateChanged() => OnChange?.Invoke();
        #endregion

        #endregion
    }
}