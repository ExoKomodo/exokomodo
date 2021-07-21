using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<Touch[]> Touches => _JS.InvokeAsync<Touch[]>(
            _p5GetValue,
            "touches"
        );
        #endregion

        #region Hooks
        [JSInvokable("touchEnded")]
        public virtual bool TouchEnded()
        {
            return true; // Event prevent default
        }

        [JSInvokable("touchMoved")]
        public virtual bool TouchMoved()
        {
            return true; // Event prevent default
        }

        [JSInvokable("touchStarted")]
        public virtual bool TouchStarted()
        {
            return true; // Event prevent default
        }
        #endregion

        #endregion
    }
}