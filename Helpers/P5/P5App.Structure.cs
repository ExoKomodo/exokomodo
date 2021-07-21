using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<bool> DisableFriendlyErrors
        {
            get => _JS.InvokeAsync<bool>(
                _p5GetValue,
                "disableFriendlyErrors"
            );
            set => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "disableFriendlyErrorsDotnet",
                value
            );
        }
        
        public ValueTask<bool> IsLooping =>
            _JS.InvokeAsync<bool>(
                _p5InvokeFunctionAndReturn,
                "isLooping"
            );
        #endregion

        #region Hooks
        [JSInvokable("draw")]
        public abstract Task Draw();

        [JSInvokable("preload")]
        public virtual async Task Preload() => await Task.Yield();

        [JSInvokable("setup")]
        public abstract Task Setup();
        #endregion

        #region Member Methods
        public ValueTask<bool> Fullscreen() =>
            _JS.InvokeAsync<bool>(
                _p5InvokeFunctionAndReturn,
                "fullscreen"
            );

        public ValueTask Fullscreen(bool isFullscreen) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "fullscreen",
                isFullscreen
            );
    
        public ValueTask Loop() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "loop"
            );

        public ValueTask NoLoop() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noLoop"
            );

        public ValueTask<float> PixelDensity() =>
            _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "pixelDensity"
            );

        public ValueTask PixelDensity(float density) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "pixelDensity",
                density
            );

        public ValueTask Pop() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "pop"
            );

        public ValueTask Push() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "push"
            );

        public ValueTask Redraw(uint times = 1) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "redraw",
                times
            );

        public ValueTask Remove() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "remove"
            );
        #endregion

        #endregion
    }
}
