using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public bool DisableFriendlyErrors
        {
            get => _jsRuntime.Invoke<bool>(
                _p5GetValue,
                "disableFriendlyErrors"
            );
            set => _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "disableFriendlyErrorsDotnet",
                value
            );
        }
        
        public bool IsLooping => _jsRuntime.Invoke<bool>(
            _p5InvokeFunctionAndReturn,
            "isLooping"
        );
        #endregion

        #region Hooks
        [JSInvokable("draw")]
        public abstract void Draw();

        [JSInvokable("preload")]
        public virtual void Preload() {}

        [JSInvokable("setup")]
        public abstract void Setup();
        #endregion

        #region Member Methods
        public bool Fullscreen() => _jsRuntime.Invoke<bool>(
            _p5InvokeFunctionAndReturn,
            "fullscreen"
        );

        public void Fullscreen(bool isFullscreen)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fullscreen",
                isFullscreen
            );
        }
    
        public void Loop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "loop"
            );
        }

        public void NoLoop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noLoop"
            );
        }

        public float PixelDensity() => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "pixelDensity"
        );

        public void PixelDensity(float density)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pixelDensity",
                density
            );
        }

        public void Pop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pop"
            );
        }

        public void Push()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "push"
            );
        }

        public void Redraw(uint times = 1)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "redraw",
                times
            );
        }

        public void Remove()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "remove"
            );
        }
        #endregion

        #endregion
    }
}
