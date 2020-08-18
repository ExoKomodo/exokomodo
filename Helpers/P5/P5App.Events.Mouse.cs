using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        // Careful calling this function if the mouse is not currently pressed
        public string MouseButton => _jsRuntime.Invoke<string>(
            _p5GetValue,
            "mouseButton"
        );
        public bool MouseIsPressed => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "mouseIsPressed"
        );
        public double MouseX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "mouseX"
        );
        public double MouseXPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pmouseX"
        );
        public double MouseY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "mouseY"
        );
        public double MouseYPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pmouseY"
        );
        public double MouseMovedX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "movedX"
        );
        public double MouseMovedY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "movedY"
        );
        public double WindowMouseX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "winMouseX"
        );
        public double WindowMouseXPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pwinMouseX"
        );
        public double WindowMouseY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "winMouseY"
        );
        public double WindowMouseYPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pwinMouseY"
        );
        #endregion

        #region Hooks
        [JSInvokable("mouseClicked")]
        public virtual bool MouseClicked()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseDragged")]
        public virtual bool MouseDragged()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public virtual bool MouseMoved()
        {
            return false; // Event prevent default
        }
        
        [JSInvokable("mousePressed")]
        public virtual bool MousePressed()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseReleased")]
        public virtual bool MouseReleased()
        {
            return false; // Event prevent default
        }
        #endregion

        #region Member Methods
        public void ExitPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "exitPointerLock"
            );
        }

        public void RequestPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "requestPointerLock"
            );
        }
        #endregion

        #endregion
    }
}