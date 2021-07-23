using Client.Helpers.P5.Models;
using System;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public float Noise(float x) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x
        );

        public float Noise(float x, float y) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x,
            y
        );

        public float Noise(float x, float y, float z) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "noise",
            x,
            y,
            z
        );

        public float Noise(Vector2 dimensions) => Noise(
            dimensions.X,
            dimensions.Y
        );

        public float Noise(Vector3 dimensions) => Noise(
            dimensions.X,
            dimensions.Y,
            dimensions.Z
        );

        public float NoiseDetail(float lod, float falloff) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "noiseDetail",
            lod,
            Math.Clamp(falloff, 0, 1)
        );

        public float NoiseSeed(float seed) => _jsRuntime.Invoke<float>(
            _p5InvokeFunctionAndReturn,
            "noiseSeed",
            seed
        );
        #endregion

        #endregion
    }
}