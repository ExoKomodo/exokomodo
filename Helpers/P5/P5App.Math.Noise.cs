using ExoKomodo.Helpers.P5.Models;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public double Noise(double x) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x
        );

        public double Noise(double x, double y) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x,
            y
        );

        public double Noise(double x, double y, double z) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x,
            y,
            z
        );

        public double Noise(Vector2 dimensions) => Noise(
            dimensions.X,
            dimensions.Y
        );

        public double Noise(Vector3 dimensions) => Noise(
            dimensions.X,
            dimensions.Y,
            dimensions.Z
        );

        public double NoiseDetail(double lod, double falloff) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noiseDetail",
            lod,
            Math.Clamp(falloff, 0, 1)
        );

        public double NoiseSeed(double seed) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noiseSeed",
            seed
        );
        #endregion

        #endregion
    }
}