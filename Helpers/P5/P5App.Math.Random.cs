using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask<float> RandomGaussian(float mean, float standardDeviation) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "randomGaussian",
            mean,
            standardDeviation
        );
        #endregion

        #endregion
    }
}
