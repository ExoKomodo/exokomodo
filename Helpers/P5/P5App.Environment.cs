using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public double DeltaTime => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "deltaTime"
        );

        public double DisplayDensity => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "displayDensity"
        );

        public uint DisplayHeight => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "displayHeight"
        );

        public double DisplayWidth => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "displayWidth"
        );

        public uint FrameCount => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "frameCount"
        );
        
        public uint Height => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "height"
        );

        public bool IsFocused => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "focused"
        );

        public string Url => _jsRuntime.Invoke<string>(
            _p5InvokeFunctionAndReturn,
            "getURL"
        );
        
        public string UrlPath => _jsRuntime.Invoke<string>(
            _p5InvokeFunctionAndReturn,
            "getURLPath"
        );
        
        public double Width => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "width"
        );

        public uint WindowHeight => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "windowHeight"
        );

        public double WindowWidth => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "windowWidth"
        );
        #endregion

        #region Hooks
        [JSInvokable("windowResized")]
        public virtual void WindowResized() {}
        #endregion

        #region Member Methods
        public void Cursor(Enums.CursorMode mode)
        {
            var cursorMode = "";
            switch (mode)
            {
                case Enums.CursorMode.Arrow:
                    cursorMode = "default";
                    break;
                case Enums.CursorMode.Cross:
                    cursorMode = "crosshair";
                    break;
                case Enums.CursorMode.Hand:
                    cursorMode = "pointer";
                    break;
                case Enums.CursorMode.Move:
                    cursorMode = "move";
                    break;
                case Enums.CursorMode.Text:
                    cursorMode = "text";
                    break;
                case Enums.CursorMode.Wait:
                    cursorMode = "wait";
                    break;
                default:
                    throw new Exception("Invalid CursorMode");
            }
            Cursor(cursorMode);
        }

        public void Cursor(Enums.CursorMode mode, uint x, uint y)
        {
            var cursorMode = "";
            switch (mode)
            {
                case Enums.CursorMode.Arrow:
                    cursorMode = "default";
                    break;
                case Enums.CursorMode.Cross:
                    cursorMode = "crosshair";
                    break;
                case Enums.CursorMode.Hand:
                    cursorMode = "pointer";
                    break;
                case Enums.CursorMode.Move:
                    cursorMode = "move";
                    break;
                case Enums.CursorMode.Text:
                    cursorMode = "text";
                    break;
                case Enums.CursorMode.Wait:
                    cursorMode = "wait";
                    break;
                default:
                    throw new Exception("Invalid CursorMode");
            }
            Cursor(cursorMode, x, y);
        }

        public void Cursor(string mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cursor",
                mode
            );
        }

        public void Cursor(string mode, uint x, uint y)
        {
            x = Math.Min(x, 32);
            y = Math.Min(y, 32);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cursor",
                mode,
                x,
                y
            );
        }

        public double FrameRate() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "frameRate"
        );

        public void FrameRate(double fps)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "frameRate",
                fps
            );
        }

        public void NoCursor()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noCursor"
            );
        }
        #endregion

        #endregion
    }
}