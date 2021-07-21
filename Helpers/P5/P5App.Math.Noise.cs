using Microsoft.JSInterop;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask<float> Noise(float x) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x
        );

        public ValueTask<float> Noise(float x, float y) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x,
            y
        );

        public ValueTask<float> Noise(float x, float y, float z) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x,
            y,
            z
        );

        public ValueTask<float> Noise(Vector2 dimensions) => Noise(
            dimensions.X,
            dimensions.Y
        );

        public ValueTask<float> Noise(Vector3 dimensions) => Noise(
            dimensions.X,
            dimensions.Y,
            dimensions.Z
        );

        public ValueTask<float> NoiseDetail(float lod, float falloff) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "noiseDetail",
            lod,
            Math.Clamp(falloff, 0, 1)
        );

        public ValueTask<float> NoiseSeed(float seed) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "noiseSeed",
            seed
        );
        #endregion

        #endregion
    }
}