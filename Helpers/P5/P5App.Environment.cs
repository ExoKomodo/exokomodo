using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<float> DeltaTime => _JS.InvokeAsync<float>(
            _p5GetValue,
            "deltaTime"
        );

        public ValueTask<float> DisplayDensity => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "displayDensity"
        );

        public ValueTask<uint> DisplayHeight => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "displayHeight"
        );

        public ValueTask<uint> DisplayWidth => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "displayWidth"
        );

        public ValueTask<uint> FrameCount => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "frameCount"
        );
        
        public ValueTask<uint> Height => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "height"
        );

        public ValueTask<bool> IsFocused => _JS.InvokeAsync<bool>(
            _p5GetValue,
            "focused"
        );

        public ValueTask<string> Url => _JS.InvokeAsync<string>(
            _p5InvokeFunctionAndReturn,
            "getURL"
        );
        
        public ValueTask<string> UrlPath => _JS.InvokeAsync<string>(
            _p5InvokeFunctionAndReturn,
            "getURLPath"
        );
        
        public ValueTask<uint> Width => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "width"
        );

        public ValueTask<uint> WindowHeight => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "windowHeight"
        );

        public ValueTask<uint> WindowWidth => _JS.InvokeAsync<uint>(
            _p5GetValue,
            "windowWidth"
        );
        #endregion

        #region Hooks
        [JSInvokable("windowResized")]
        public virtual void WindowResized() {}
        #endregion

        #region Member Methods
        public ValueTask Cursor(CursorMode mode) => Cursor(CursorModeToString(mode));

        public ValueTask Cursor(CursorMode mode, uint x, uint y) => Cursor(CursorModeToString(mode), x, y);

        public ValueTask Cursor(string mode)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "cursor",
                mode
            );
        }

        public ValueTask Cursor(string mode, uint x, uint y)
        {
            x = Math.Min(x, 32);
            y = Math.Min(y, 32);
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "cursor",
                mode,
                x,
                y
            );
        }

        public ValueTask<float> FrameRate()
        {
            return _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "frameRate"
            );
        }

        public ValueTask FrameRate(float fps)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "frameRate",
                fps
            );
        }

        public ValueTask NoCursor()
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noCursor"
            );
        }
        #endregion

        #region Static Methods
        public static string CursorModeToString(CursorMode mode) => mode switch
        {
            CursorMode.Arrow => "default",
            CursorMode.Cross => "crosshair",
            CursorMode.Hand => "pointer",
            CursorMode.Move => "move",
            CursorMode.Text => "text",
            CursorMode.Wait => "wait",
            _ => throw new Exception("Invalid CursorMode"),
        };
        #endregion

        #endregion
    }
}