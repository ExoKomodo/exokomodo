using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.Browser
{
    public class LocalStorage
    {
        #region Public

        #region Constructors
        public LocalStorage(IJSRuntime JS)
        {
            _JS = JS;
        }
        #endregion

        #region Member Methods
        public T Load<T>(string key)
        {
            return _JS.InvokeAsync<T>("loadFromLocalStorage", key).Result;
        }

        public void Save(string key, object obj)
        {
            _JS.InvokeVoidAsync("saveToLocalStorage", key, obj).AsTask().Wait();
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        protected readonly IJSRuntime _JS;
        #endregion

        #endregion
    }
}
