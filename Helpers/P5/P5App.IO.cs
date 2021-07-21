using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public ValueTask<float> Millis => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "millis"
        );
        #endregion

        #endregion
    }
}
