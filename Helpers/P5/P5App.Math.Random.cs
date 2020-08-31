using System;
namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public float RandomGaussian(float mean, float standardDeviation) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "randomGaussian",
            mean,
            standardDeviation
        );
        #endregion

        #endregion
    }
}
