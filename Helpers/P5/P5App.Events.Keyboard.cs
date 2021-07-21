using ExoKomodo.Enums;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<string> Key =>
            _JS.InvokeAsync<string>(
                _p5GetValue,
                "key"
            );
        public ValueTask<KeyCodes> KeyCode =>
            _JS.InvokeAsync<KeyCodes>(
                _p5GetValue,
                "keyCode"
            );
        public ValueTask<bool> KeyIsPressed =>
            _JS.InvokeAsync<bool>(
                _p5GetValue,
                "keyIsPressed"
            );
        #endregion

        #region Hooks
        [JSInvokable("keyPressed")]
        public virtual async Task<bool> KeyPressed() => await Task.FromResult(true); // Event prevent default

        [JSInvokable("keyReleased")]
        public virtual async Task<bool> KeyReleased() => await Task.FromResult(true); // Event prevent default

        [JSInvokable("keyTyped")]
        public virtual async Task<bool> KeyTyped() => await Task.FromResult(true); // Event prevent default
        #endregion

        #region Member Methods
        public ValueTask<bool> IsKeyDown(KeyCodes code) =>
            _JS.InvokeAsync<bool>(
                _p5InvokeFunctionAndReturn,
                "keyIsDown",
                code
            );
        #endregion

        #endregion
    }
}