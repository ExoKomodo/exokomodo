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
        public float MouseX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "mouseX"
        );
        public float MouseXPrevious => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pmouseX"
        );
        public float MouseY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "mouseY"
        );
        public float MouseYPrevious => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pmouseY"
        );
        public float MouseMovedX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "movedX"
        );
        public float MouseMovedY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "movedY"
        );
        public float WindowMouseX => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "winMouseX"
        );
        public float WindowMouseXPrevious => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pwinMouseX"
        );
        public float WindowMouseY => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "winMouseY"
        );
        public float WindowMouseYPrevious => _jsRuntime.Invoke<float>(
            _p5GetValue,
            "pwinMouseY"
        );
        #endregion

        #region Hooks
        [JSInvokable("mouseClicked")]
        public virtual bool MouseClicked()
        {
            return true; // Event prevent default
        }

        [JSInvokable("mouseDragged")]
        public virtual bool MouseDragged()
        {
            return true; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public virtual bool MouseMoved()
        {
            return true; // Event prevent default
        }
        
        [JSInvokable("mousePressed")]
        public virtual bool MousePressed()
        {
            return true; // Event prevent default
        }

        [JSInvokable("mouseReleased")]
        public virtual bool MouseReleased()
        {
            return true; // Event prevent default
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