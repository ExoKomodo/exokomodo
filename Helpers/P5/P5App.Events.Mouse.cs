using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public async Task<Vector2> GetPreviousMousePosition() => new Vector2(await MouseXPrevious, await MouseYPrevious);
        // Careful calling this function if the mouse is not currently pressed
        public async Task<MouseButtons> GetMouseButton() =>
            await Task.Run(async () => {
                var button = await _JS.InvokeAsync<string>(
                    _p5GetValue,
                    "mouseButton"
                );
                return button switch
                {
                    "center" => MouseButtons.Center,
                    "left" => MouseButtons.Left,
                    "right" => MouseButtons.Right,
                    _ => throw new Exception("Invalid MouseButton"),
                };
            });
        public ValueTask<bool> MouseIsPressed => _JS.InvokeAsync<bool>(
            _p5GetValue,
            "mouseIsPressed"
        );
        public async Task<Vector2> GetMousePosition() => new Vector2(await MouseX, await MouseY);
        public ValueTask<float> MouseX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "mouseX"
        );
        public ValueTask<float> MouseXPrevious => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pmouseX"
        );
        public ValueTask<float> MouseY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "mouseY"
        );
        public ValueTask<float> MouseYPrevious => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pmouseY"
        );
        public ValueTask<float> MouseMovedX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "movedX"
        );
        public ValueTask<float> MouseMovedY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "movedY"
        );
        public ValueTask<float> WindowMouseX => _JS.InvokeAsync<float>(
            _p5GetValue,
            "winMouseX"
        );
        public ValueTask<float> WindowMouseXPrevious => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pwinMouseX"
        );
        public ValueTask<float> WindowMouseY => _JS.InvokeAsync<float>(
            _p5GetValue,
            "winMouseY"
        );
        public ValueTask<float> WindowMouseYPrevious => _JS.InvokeAsync<float>(
            _p5GetValue,
            "pwinMouseY"
        );
        #endregion

        #region Hooks
        [JSInvokable("doubleClicked")]
        public virtual async Task<bool> DoubleClicked() =>
            await Task.FromResult(true); // event prevent default

        [JSInvokable("mouseClicked")]
        public virtual async Task<bool> MouseClicked() =>
            await Task.FromResult(true); // event prevent default

        [JSInvokable("mouseDragged")]
        public virtual async Task<bool> MouseDragged() =>
            await Task.FromResult(true); // event prevent default

        [JSInvokable("mouseMoved")]
        public virtual async Task<bool> MouseMoved() =>
            await Task.FromResult(true); // event prevent default
        
        [JSInvokable("mousePressed")]
        public virtual async Task<bool> MousePressed() =>
            await Task.FromResult(true); // event prevent default

        [JSInvokable("mouseReleased")]
        public virtual async Task<bool> MouseReleased() =>
            await Task.FromResult(true); // event prevent default

        [JSInvokable("mouseWheel")]
        public virtual async Task<bool> MouseWheel(float delta) =>
            await Task.FromResult(true); // event prevent default
        #endregion

        #region Member Methods
        public ValueTask ExitPointerLock() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "exitPointerLock"
            );

        public ValueTask RequestPointerLock() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "requestPointerLock"
            );
        #endregion

        #endregion
    }
}