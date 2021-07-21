using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App : IDisposable
    {
        #region Public

        #region Static Members
        public static P5App Instance { get; protected set; }
        #endregion

        #region Members
        public bool IsWebGl { get; protected set; }
        #endregion

        #region Member Methods
        public DotNetObjectReference<P5App> GetJsInteropReference()
        {
            return DotNetObjectReference.Create(this);
        }

        public async void ReloadPage()
        {
            await _JS.InvokeVoidAsync("location.reload");
            Instance = null;
        }

        public ValueTask Start(string containerId = null) =>
            _JS.InvokeVoidAsync(
                "startP5",
                GetJsInteropReference(),
                containerId ?? _containerId
            );

        public ValueTask StartAsync(string containerId = null) =>
            _JS.InvokeVoidAsync(
                "startP5",
                GetJsInteropReference(),
                containerId ?? _containerId
            );
        #endregion

        #endregion

        #region Protected

        #region Constants
        protected const string _p5InvokeFunction = "p5Instance.invokeP5Function";
        protected const string _p5InvokeFunctionAndReturn = "p5Instance.invokeP5FunctionAndReturn";
        protected const string _p5GetValue = "p5Instance.getValue";
        #endregion

        #region Constructors
        protected P5App(IJSRuntime JS, string containerId)
        {
            if (Instance is not null)
            {
                throw new Exception("Only one P5App should exist at once");
            }
            Instance = this;
            _JS = JS;
            _containerId = containerId;
        }
        #endregion

        #region Members
        protected bool _isDisposed { get; set; }
        protected readonly IJSRuntime _JS;
        protected readonly string _containerId;
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
            if (Instance is null || _isDisposed || !disposing)
            {
                return;
            }
            // This is necessary to reset the p5 sketch context
            ReloadPage();
            Instance = null;
            _isDisposed = true;
        }
        #endregion
    }
}